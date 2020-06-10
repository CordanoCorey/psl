import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { SmartComponent, Control, routeParamIdSelector, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { User } from 'src/app/shared/models';
import { UsersActions } from 'src/app/shared/actions';
import { userSelector } from 'src/app/shared/selectors';

@Component({
  selector: 'psl-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent extends SmartComponent implements OnInit {

  @Control(User) form: FormGroup;
  _user: User = new User();
  user$: Observable<User>;
  _userId = 0;
  userId$: Observable<number>;

  constructor(public store: Store<any>) {
    super(store);
    this.user$ = userSelector(store);
    this.userId$ = routeParamIdSelector(store, 'userId');
  }

  set user(value: User) {
    this._user = value;
    this.setValue(value);
  }

  get user(): User {
    return this._user;
  }

  set userId(value: number) {
    this._userId = value;
    if (value !== 0) {
      this.getUser(value);
    }
  }

  get userId(): number {
    return this._userId;
  }

  ngOnInit(): void {
    this.sync(['user', 'userId']);
  }

  getUser(id: number) {
    this.dispatch(HttpActions.get(`users/${id}`, UsersActions.GET));
  }

}
