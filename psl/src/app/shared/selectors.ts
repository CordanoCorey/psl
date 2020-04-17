import { build, Token, routeParamSelector, routeParamIdSelector, compareStrings, compareNumbers, truthy } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, interval, combineLatest } from 'rxjs';
import { map, distinctUntilChanged, take } from 'rxjs/operators';

import { CurrentUser, User, Users } from './models';

export function activeUserSelector(store: Store<any>): Observable<User> {
  return combineLatest(store.select('users'), routeParamIdSelector(store, 'userId'), (users, id) => users.get(id));
}

export function activeUserNameSelector(store: Store<any>): Observable<string> {
  return activeUserSelector(store).pipe(
    map(x => x.firstName),
    distinctUntilChanged()
  );
}

export function activeUserIdSelector(store: Store<any>): Observable<number> {
  return activeUserSelector(store).pipe(
    map(x => x.id),
    distinctUntilChanged()
  );
}

export function authenticatedSelector(store: Store<any>): Observable<boolean> {
  return currentUserSelector(store).pipe(
    map(user => user.authenticated),
    take(1)
  );
}

export function authTokenSelector(store: Store<any>): Observable<string> {
  return currentUserSelector(store).pipe(
    map(user => {
      const token: Token = user && user.token ? build(Token, user.token) : new Token();
      return token.toString();
    })
  );
}

export function redirectToSelector(store: Store<any>): Observable<string> {
  return routeParamSelector(store, 'redirectTo', 'dashboard').pipe(distinctUntilChanged());
}

export function currentUserSelector(store: Store<any>): Observable<CurrentUser> {
  return store.select('currentUser').pipe(map(user => {
    return build(CurrentUser, user);
  }));
}

export function currentUserIdSelector(store: Store<any>): Observable<number> {
  return currentUserSelector(store).pipe(
    map(x => 1),
    distinctUntilChanged()
  );
}

export function usersSelector(store: Store<any>): Observable<Users> {
  return store.select('users');
}

export function allUsersSelector(store: Store<any>): Observable<User[]> {
  return usersSelector(store).pipe(
    map(x => x.asArray)
  );
}

export function isSysAdminSelector(store: Store<any>): Observable<boolean> {
  return currentUserSelector(store).pipe(
    map(x => true)
  );
}

export function accessGrantedSelector(store: Store<any>): Observable<boolean> {
  return store.select('accessGranted').pipe(
    map(x => truthy(x))
  );
}
