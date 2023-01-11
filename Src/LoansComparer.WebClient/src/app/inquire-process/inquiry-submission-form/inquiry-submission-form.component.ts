import { Component, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition,
} from '@angular/animations';
import { MatDialog } from '@angular/material/dialog';
import { SuccessMessageComponent } from './success-message/success-message.component';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/services/auth/auth.service';
import { FormGroup } from '@angular/forms';
import { LoansComparerService } from 'src/app/shared/services/loans-comparer/loans-comparer.service';
import {
  InquireDataStorageService,
  InquiryDetails,
} from '../services/inquire-data-storage.service';

@Component({
  selector: 'app-inquiry-submission-form',
  templateUrl: './inquiry-submission-form.component.html',
  styleUrls: ['./inquiry-submission-form.component.less'],
  animations: [
    trigger('displayForm', [
      state('*', style({ opacity: 1 })),
      state('void', style({ opacity: 0 })),
      transition(':enter', [animate('0.75s ease-in')]),
      transition(':leave', [animate('0.75s ease-in')]),
    ]),
  ],
})
export class InquirySubmissionFormComponent implements OnInit {
  form = new FormGroup({});
  inquiry!: InquiryDetails;

  constructor(
    protected authService: AuthService,
    protected router: Router,
    protected popup: MatDialog,
    protected inquireDataStorageService: InquireDataStorageService,
    protected loansComparerService: LoansComparerService
  ) {}

  ngOnInit(): void {
    if (this.inquireDataStorageService.hasAllData) {
      this.inquiry = this.inquireDataStorageService.getInquiryDetails();
    } else {
      this.router.navigate(['/inquire']);
    }
  }

  onFormSubmit(): void {
    this.openSuccessfulPopup();
  }

  openSuccessfulPopup(): void {
    const popupRef = this.popup.open(SuccessMessageComponent, {
      height: '210px',
      width: '400px',
    });

    popupRef.afterClosed().subscribe(() => {
      if (this.authService.isAuthenticated) {
        this.router.navigate(['/home']);
      } else {
        this.router.navigate(['']);
      }
    });
  }
}