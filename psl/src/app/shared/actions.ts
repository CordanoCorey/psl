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

export class AccessCodeActions {
  static SET = '[AccessCode] SET';

  static setValue(payload: string): Action {
    return {
      type: AccessCodeActions.SET,
      payload
    };
  }
}

export class WidgetsActions {
  static DELETE = '[Widgets] DELETE';
  static GET = '[Widgets] GET';
  static POST = '[Widgets] POST';
  static POST_ERROR = '[Widgets] POST ERROR';
  static PUT = '[Widgets] PUT';
}
