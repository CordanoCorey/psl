import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject } from 'rxjs';

import { RoutingsQuery, Routing } from '../routings.model';
import { routingsSearchSelector, RoutingsActions } from '../routings.reducer';
@Component({
  selector: 'psl-routings-grid',
  templateUrl: './routings-grid.component.html',
  styleUrls: ['./routings-grid.component.scss']
})
export class RoutingsGridComponent extends SmartComponent implements OnInit {

  pageSubject = new BehaviorSubject<PageEvent>(null);
  _query: RoutingsQuery = new RoutingsQuery();
  query$: Observable<RoutingsQuery>;
  searchTotal = 100;
  sortSubject = new BehaviorSubject<Sort>(null);
  routings: Routing[] = [];
  routings$: Observable<Routing[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.routings$ = routingsSearchSelector(store);
  }

  get displayedColumns(): string[] {
    return ['id', 'carrierName', 'startDate', 'originName', 'originCity', 'originState', 'destinationName', 'destinationCity', 'destinationState'];
  }

  set query(value: RoutingsQuery) {
    this._query = value;
  }

  get query(): RoutingsQuery {
    return this._query;
  }

  ngOnInit(): void {
    this.sync(['routings']);
    this.getRoutings();
  }

  getRoutings() {
    this.dispatch(HttpActions.get(`routings`, RoutingsActions.GET));
  }

  onSort(e) {

  }

}
