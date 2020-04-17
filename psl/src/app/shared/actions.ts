import { Action } from '@caiu/library';

import { User } from './models';

export class CurrentUserActions {
  static LOGIN = '[CurrentUser] Login';
  static LOGIN_ERROR = '[CurrentUser] Login Error';
  static LOGOUT = '[CurrentUser] Logout';
  static GENERATE_PASSWORD_RESET_CODE = '[CurrentUser] Reset Password Code';
  static RESET_PASSWORD = '[CurrentUser] Reset Password';
  static RESET_PASSWORD_ERROR = '[CurrentUser] Reset Password Error';
  static SIGNUP = '[CurrentUser] Signup';
  static ALL = [CurrentUserActions.LOGIN, CurrentUserActions.LOGOUT, CurrentUserActions.RESET_PASSWORD];

  static loginSuccess(payload: User): Action {
    return {
      type: CurrentUserActions.LOGIN,
      payload
    };
  }

  static loginError(payload: any): Action {
    return {
      type: CurrentUserActions.LOGIN_ERROR,
      payload
    };
  }

  static logout(): Action {
    return {
      type: CurrentUserActions.LOGOUT
    };
  }
}

export class UsersActions {
  static GET = '[Users] GET';
}

export class AccessGrantedActions {
  static SET = '[AccessGranted] SET';

  static setValue(payload: boolean): Action {
    return {
      type: AccessGrantedActions.SET,
      payload
    };
  }
}
