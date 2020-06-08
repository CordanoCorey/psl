import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { SmartComponent, Control, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject } from 'rxjs';

import { User, UsersQuery } from '../shared/models';
import { allUsersSelector, isSysAdminSelector } from '../shared/selectors';
import { UsersActions } from '../shared/actions';

@Component({
  selector: 'psl-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends SmartComponent implements OnInit {

  @Control(UsersQuery) form: FormGroup;
  isAccountAdmin = true;
  isSysAdmin$: Observable<boolean>;
  pageSubject = new BehaviorSubject<PageEvent>(null);
  _query: UsersQuery = new UsersQuery();
  query$: Observable<UsersQuery>;
  searchTotal = 100;
  sortSubject = new BehaviorSubject<Sort>(null);
  users: User[] = [];
  users$: Observable<User[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.isSysAdmin$ = isSysAdminSelector(store);
    this.users$ = allUsersSelector(store);
  }

  get displayedColumns(): string[] {
    return ['firstName', 'lastName', 'email', 'title', 'role', 'locked', 'active', 'actions'];
  }

  set query(value: UsersQuery) {
    this._query = value;
  }

  get query(): UsersQuery {
    return this._query;
  }

  ngOnInit(): void {
    this.sync(['users']);
    this.getUsers();
    this.users$.subscribe(x => { console.dir(x); });
  }

  getUsers() {
    this.dispatch(HttpActions.get(`users`, UsersActions.GET));
  }

  impersonate(e) {

  }

  onSort(e) {

  }

}
