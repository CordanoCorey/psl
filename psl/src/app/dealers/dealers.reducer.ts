import { Action } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Dealers } from './dealers.model';

export class DealersActions {
  static GET = '[Dealers] GET';
}

export function dealersReducer(state: Dealers = new Dealers(), action: Action): Dealers {
  switch (action.type) {

    case DealersActions.GET:
      return state.update(action.payload);

    default:
      return state;
  }
}

export function dealersSelector(store: Store<any>): Observable<Dealers> {
  return store.select('dealers');
}
