import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject } from 'rxjs';

import { DealersQuery, Dealer } from '../dealers.model';
import { dealersSearchSelector, DealersActions } from '../dealers.reducer';

@Component({
  selector: 'psl-dealers-grid',
  templateUrl: './dealers-grid.component.html',
  styleUrls: ['./dealers-grid.component.scss']
})
export class DealersGridComponent extends SmartComponent implements OnInit {

  pageSubject = new BehaviorSubject<PageEvent>(null);
  _query: DealersQuery = new DealersQuery();
  query$: Observable<DealersQuery>;
  searchTotal = 100;
  sortSubject = new BehaviorSubject<Sort>(null);
  dealers: Dealer[] = [];
  dealers$: Observable<Dealer[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.dealers$ = dealersSearchSelector(store);
  }

  get displayedColumns(): string[] {
    return ['src', 'name'];
  }

  set query(value: DealersQuery) {
    this._query = value;
  }

  get query(): DealersQuery {
    return this._query;
  }

  ngOnInit(): void {
    this.sync(['dealers']);
    this.getDealers();
    this.dealers$.subscribe(x => { console.dir(x); });
  }

  onSort(e) {

  }

  getDealers() {
    this.dispatch(HttpActions.get(`dealers`, DealersActions.GET));
  }

}
