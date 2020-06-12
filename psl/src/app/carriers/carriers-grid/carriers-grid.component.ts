import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject } from 'rxjs';

import { CarriersQuery, Carrier } from '../carriers.model';
import { carriersSearchSelector, CarriersActions } from '../carriers.reducer';

@Component({
  selector: 'psl-carriers-grid',
  templateUrl: './carriers-grid.component.html',
  styleUrls: ['./carriers-grid.component.scss']
})
export class CarriersGridComponent extends SmartComponent implements OnInit {

  pageSubject = new BehaviorSubject<PageEvent>(null);
  _query: CarriersQuery = new CarriersQuery();
  query$: Observable<CarriersQuery>;
  searchTotal = 100;
  sortSubject = new BehaviorSubject<Sort>(null);
  carriers: Carrier[] = [];
  carriers$: Observable<Carrier[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.carriers$ = carriersSearchSelector(store);
  }

  get displayedColumns(): string[] {
    return ['src', 'name'];
  }

  set query(value: CarriersQuery) {
    this._query = value;
  }

  get query(): CarriersQuery {
    return this._query;
  }

  ngOnInit(): void {
    this.sync(['carriers']);
    this.getCarriers();
    this.carriers$.subscribe(x => { console.dir(x); });
  }

  onSort(e) {

  }

  getCarriers() {
    this.dispatch(HttpActions.get(`carriers`, CarriersActions.GET));
  }

}
