import { Action, routeParamIdSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Routings, Routing } from './routings.model';

export class RoutingsActions {
  static GET = '[Routings] GET';
  static POST = '[Routings] POST';
}

export class RoutingActions {
  static DELETE = '[Routings] DELETE';
  static GET = '[Routings] GET';
  static PUT = '[Routings] PUT';
}

export function routingsReducer(state: Routings = new Routings(), action: Action): Routings {
  switch (action.type) {

    case RoutingsActions.GET:
      console.dir(action.payload);
      return state.update(action.payload);

    default:
      return state;
  }
}

export function routingsSelector(store: Store<any>): Observable<Routings> {
  return store.select('routings');
}

export function routingSelector(store: Store<any>): Observable<Routing> {
  return combineLatest(routingsSelector(store), routeParamIdSelector(store, 'routingId'), (routings, id) => routings.get(id));
}

export function routingsSearchSelector(store: Store<any>): Observable<Routing[]> {
  return routingsSelector(store).pipe(
    map(x => x.asArray)
  );
}
