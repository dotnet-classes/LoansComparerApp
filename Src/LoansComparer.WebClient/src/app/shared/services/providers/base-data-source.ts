import { BehaviorSubject, Observable } from 'rxjs';
import { LoansComparerService } from '../loans-comparer/loans-comparer.service';
import { CollectionViewer, DataSource } from '@angular/cdk/collections';

export class BaseDataSource<T> implements DataSource<T> {
  protected data = new BehaviorSubject<T[]>([]);
  protected loading = new BehaviorSubject<boolean>(false);

  public loading$ = this.loading.asObservable();

  constructor(protected loansComparerService: LoansComparerService) {}

  connect(collectionViewer: CollectionViewer): Observable<readonly T[]> {
    return this.data.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.data.complete();
    this.loading.complete();
  }
}
