import { build, Token, StorageActions, Action } from '@caiu/library';

import { UsersActions, AccessGrantedActions } from './actions';
import { CurrentUser, Users } from './models';

export function accessGrantedReducer(state: boolean = false, action: Action): boolean {
  switch (action.type) {
    case AccessGrantedActions.SET:
      return action.payload;

    default:
      return state;
  }
}

export function currentUserReducer(state: CurrentUser = new CurrentUser(), action: Action): CurrentUser {
  switch (action.type) {
    case StorageActions.INIT_STORE:
      return CurrentUser.Build(action.payload.localStore ? action.payload.localStore.currentUser : {});

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
