import { build, Token, StorageActions, Action } from '@caiu/library';

import { UsersActions, AccessCodeActions, WidgetsActions, CurrentUserActions } from './actions';
import { CurrentUser, Users, Widgets } from './models';

export function accessCodeReducer(state = '', action: Action): string {
  switch (action.type) {
    case AccessCodeActions.SET:
      return action.payload;

    case StorageActions.INIT_STORE:
      return action.payload.localStore ? action.payload.localStore.accessCode : '';

    default:
      return state;
  }
}

export function currentUserReducer(state: CurrentUser = new CurrentUser(), action: Action): CurrentUser {
  switch (action.type) {
    case StorageActions.INIT_STORE:
      return CurrentUser.Build(action.payload.localStore ? action.payload.localStore.currentUser : {});

    case CurrentUserActions.LOGIN:
      const token = build(Token, {
        access_token: action.payload.access_token,
        expires_in: action.payload.expires_in
      });

      return build(CurrentUser, state, action.payload.user as CurrentUser, {
        token,
        role: action.payload.role
      });

    case CurrentUserActions.LOGOUT:
      return build(CurrentUser, { token: new Token() });

    default:
      return state;
  }
}

export function usersReducer(state: Users = new Users(), action: Action): Users {
  switch (action.type) {

    case UsersActions.GET:
      return state.update(action.payload);

    default:
      return state;
  }
}

export function widgetsReducer(state: Widgets = new Widgets(), action: Action): Widgets {
  switch (action.type) {

    case WidgetsActions.GET:
    case WidgetsActions.POST:
    case WidgetsActions.PUT:
      return state.update(action.payload);

    case WidgetsActions.DELETE:
      return state.delete(action.payload);

    default:
      return state;
  }
}
