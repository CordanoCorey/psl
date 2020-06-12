import { Action, querySelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';

import { Carriers, Carrier, CarriersQuery } from './carriers.model';

export class CarriersActions {
  static GET = '[Carriers] GET';
}

export function carriersReducer(state: Carriers = new Carriers(), action: Action): Carriers {
  switch (action.type) {

    case CarriersActions.GET:
      console.dir(action.payload);
      return state.update(action.payload);

    default:
      return state;
  }
}

export function carriersSelector(store: Store<any>): Observable<Carriers> {
  return store.select('carriers');
}

export function carriersQuerySelector(store: Store<any>): Observable<CarriersQuery> {
  return querySelector(store);
}


export function carriersSearchSelector(store: Store<any>): Observable<Carrier[]> {
  return combineLatest(carriersSelector(store), carriersQuerySelector(store), (carriers, query) => carriers.asArray);
}
