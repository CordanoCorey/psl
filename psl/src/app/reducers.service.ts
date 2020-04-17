import { Injectable } from '@angular/core';
import {
  configReducer,
  errorsReducer,
  eventsReducer,
  formReducer,
  lookupReducer,
  messagesReducer,
  redirectsReducer,
  routerReducer,
  sidenavReducer,
  viewSettingsReducer,
  windowReducer
} from '@caiu/library';
import { ActionReducerMap } from '@ngrx/store';

import { routingsReducer } from './routings/routings.reducer';
import { currentUserReducer, usersReducer, accessGrantedReducer } from './shared/reducers';

@Injectable({
  providedIn: 'root'
})
export class ReducersService {

  constructor() { }

  getReducers(): ActionReducerMap<any> {
    return {
      accessGranted: accessGrantedReducer,
      currentUser: currentUserReducer,
      config: configReducer,
      errors: errorsReducer,
      events: eventsReducer,
      form: formReducer,
      lookup: lookupReducer,
      messages: messagesReducer,
      redirects: redirectsReducer,
      route: routerReducer,
      sidenav: sidenavReducer,
      viewSettings: viewSettingsReducer,
      window: windowReducer,
      users: usersReducer,
      routings: routingsReducer
    };
  }
}
