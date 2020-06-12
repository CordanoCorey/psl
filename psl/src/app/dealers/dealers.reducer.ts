import { Action, querySelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';

import { Dealers, Dealer, DealersQuery } from './dealers.model';

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

export function dealersQuerySelector(store: Store<any>): Observable<DealersQuery> {
  return querySelector(store);
}


export function dealersSearchSelector(store: Store<any>): Observable<Dealer[]> {
  return combineLatest(dealersSelector(store), dealersQuerySelector(store), (dealers, query) => dealers.asArray);
}
