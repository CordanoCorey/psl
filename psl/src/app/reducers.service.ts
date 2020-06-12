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

import { carriersReducer } from './carriers/carriers.reducer';
import { dealersReducer } from './dealers/dealers.reducer';
import { routingsReducer } from './routings/routings.reducer';
import { currentUserReducer, usersReducer, accessCodeReducer, widgetsReducer } from './shared/reducers';

@Injectable({
  providedIn: 'root'
})
export class ReducersService {

  constructor() { }

  getReducers(): ActionReducerMap<any> {
    return {
      accessCode: accessCodeReducer,
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
      widgets: widgetsReducer,
      window: windowReducer,
      users: usersReducer,
      carriers: carriersReducer,
      dealers: dealersReducer,
      routings: routingsReducer
    };
  }
}
