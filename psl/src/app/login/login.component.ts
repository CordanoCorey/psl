import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { SmartComponent, Control, ErrorOutlet, ErrorActions, HttpActions, EventsService, MessageSubscription, build, HttpService, routeParamSelector, RouterActions, truthy } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { switchMap, map, take, filter } from 'rxjs/operators';

import { Login } from '../shared/models';
import { CurrentUserActions, AccessCodeActions } from '../shared/actions';

@Component({
  selector: 'psl-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends SmartComponent implements OnInit, OnDestroy {
  @Control(Login) form: FormGroup;
  _accessCode = '';
  accessCode$: Observable<string>;
  errorMessage = '';
  successMessage = '';
  routeName = 'login';
  _showLoading = false;
  messages = [
    build(MessageSubscription, {
      action: CurrentUserActions.LOGIN_ERROR,
      channel: 'ERRORS',
      mapper: e => e.message || `Login Failed.`
    })
  ];
  userNotFound = '';
  userNotFound$: Observable<string>;

  constructor(public store: Store<any>, public events: EventsService, private http: HttpService) {
    super(store);
  }

  get credentials(): string {
    const login = <Login>this.form.value;
    return `grant_type=password&email=${this.form.value.email}&password=${this.form.value.password}`;
  }

  get errorOutlet(): ErrorOutlet {
    return {
      key: 'login'
    };
  }

  get showPasswordRequired(): boolean {
    return this.form.controls['password'].value === '' && this.form.controls['password'].touched;
  }

  get showUsernameRequired(): boolean {
    return this.form.controls['email'].value === '' && this.form.controls['email'].touched;
  }

  ngOnInit() {
    this.onInit();
    routeParamSelector(this.store, 'accessCode').pipe(
      // filter(x => truthy(x) && x !== 'undefined'),
      take(1)
    )
      .subscribe(code => {
        if (code !== '7CB24B34B9D5CC5F') {
          this.dispatch(RouterActions.navigate('/access-denied'));
        } else {
          this.dispatch(AccessCodeActions.setValue(code));
        }
      });
  }

  ngOnDestroy() {
    super.ngOnDestroy();
    this.dispatch(ErrorActions.remove('login'));
  }

  onSubmit() {
    if (this.userNotFound) {
      this.errorMessage = this.userNotFound;
      setTimeout(() => {
        this.errorMessage = null;
      }, 6000);
    } else if (this.form.valid) {
      this.dispatch(HttpActions.postFormUrlEncoded('token', this.credentials, CurrentUserActions.LOGIN, CurrentUserActions.LOGIN_ERROR));
    }
  }

  recoverPassword() {
    this.dispatch(
      HttpActions.post(`resetpassword/${this.form.controls['email'].value}`, {}, CurrentUserActions.GENERATE_PASSWORD_RESET_CODE)
    );
  }
}
