import { Component, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition,
} from '@angular/animations';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SelectType } from '../inquiry-form/inquiry-form.component';
import { ErrorMessage } from '../shared/resources/error-message';

@Component({
  selector: 'app-personal-data-form',
  templateUrl: './personal-data-form.component.html',
  styleUrls: ['./personal-data-form.component.less'],
  animations: [
    trigger('displayForm', [
      state('*', style({ opacity: 1 })),
      state('void', style({ opacity: 0 })),
      transition(':enter', [animate('0.75s ease-in')]),
      transition(':leave', [animate('0.75s ease-in')]),
    ]),
  ],
})
export class PersonalDataFormComponent implements OnInit {
  dateNow!: Date;
  dateEighteenYearsBefore!: Date;
  inquiryForm: any;

  invalidFirstNameError: string = ErrorMessage.invalidFirstName;
  invalidLastNameError: string = ErrorMessage.invalidLastName;
  invalidBirthDateError: string = ErrorMessage.invalidBirthDate;
  requiredFieldError: string = ErrorMessage.requiredField;
  invalidJobStartError: string = ErrorMessage.invalidJobStart;
  invalidJobEndError: string = ErrorMessage.invalidJobEnd;

  currencySuffix: string = 'zł';
  govIdTypesPlaceholder: SelectType[] = [
    {
      id: 1,
      name: 'Driver License',
      description: 'Driver License',
    },
    {
      id: 2,
      name: 'Passport',
      description: 'Passport',
    },
    {
      id: 3,
      name: 'Government Id',
      description: 'Government Id',
    },
  ];
  jobTypesPlaceholder: SelectType[] = [
    {
      id: 79,
      name: 'Analyst',
      description: 'Analyst',
    },
    {
      id: 80,
      name: 'Producer',
      description: 'Producer',
    },
    {
      id: 81,
      name: 'Technician',
      description: 'Technician',
    },
    {
      id: 84,
      name: 'Manager',
      description: 'Manager',
    },
    {
      id: 87,
      name: 'Liaison',
      description: 'Liaison',
    },
    {
      id: 88,
      name: 'Associate',
      description: 'Associate',
    },
    {
      id: 89,
      name: 'Consultant',
      description: 'Consultant',
    },
    {
      id: 92,
      name: 'Engineer',
      description: 'Engineer',
    },
    {
      id: 93,
      name: 'Strategist',
      description: 'Strategist',
    },
    {
      id: 94,
      name: 'Supervisor',
      description: 'Supervisor',
    },
    {
      id: 95,
      name: 'Executive',
      description: 'Executive',
    },
    {
      id: 96,
      name: 'Planner',
      description: 'Planner',
    },
    {
      id: 97,
      name: 'Developer',
      description: 'Developer',
    },
    {
      id: 98,
      name: 'Officer',
      description: 'Officer',
    },
    {
      id: 99,
      name: 'Architect',
      description: 'Architect',
    },
  ];

  constructor() {}

  ngOnInit(): void {
    this.dateNow = new Date(Date.now());

    this.dateEighteenYearsBefore = new Date(Date.now());
    this.dateEighteenYearsBefore.setFullYear(this.dateNow.getFullYear() - 18);

    this.inquiryForm = new FormGroup({
      personalData: new FormGroup({
        firstName: new FormControl('', [
          Validators.required,
          Validators.pattern('[a-zA-Z]+'),
        ]),
        lastName: new FormControl('', [
          Validators.required,
          Validators.pattern('[a-zA-Z]+'),
        ]),
        birthDate: new FormControl(null, Validators.required),
      }),
      governmentIdType: new FormControl(null, Validators.required),
      governmentId: new FormControl(null, Validators.required),
      jobType: new FormControl(null, Validators.required),
      jobStartDate: new FormControl(null, Validators.required),
      jobEndDate: new FormControl(null, Validators.required),
    });
  }

  onFormSubmit(): void {
    console.log(this.inquiryForm.value);
  }

  get jobStartDate(): Date {
    return this.inquiryForm.controls['jobStartDate'].value;
  }

  get jobEndDate(): Date {
    return this.inquiryForm.controls['jobEndDate'].value;
  }
}