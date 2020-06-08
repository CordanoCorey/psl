import { build, Token, routeParamSelector, routeParamIdSelector, compareStrings, compareNumbers, truthy, navigationEndedSelector, windowWidthSelector, windowHeightSelector, lookupValuesSelector, LookupValue } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, interval, combineLatest } from 'rxjs';
import { map, distinctUntilChanged, take, skip, withLatestFrom } from 'rxjs/operators';

import { CurrentUser, User, Users, Widgets, Widget } from './models';

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

export function userSelector(store: Store<any>): Observable<User> {
  return combineLatest(usersSelector(store), routeParamIdSelector(store, 'userId'), (users, id) => users.get(id));
}

export function isSysAdminSelector(store: Store<any>): Observable<boolean> {
  return currentUserSelector(store).pipe(
    map(x => true)
  );
}

export function widgetsSelector(store: Store<any>): Observable<Widgets> {
  return store.select('widgets');
}

export function userWidgetsSelector(store: Store<any>): Observable<Widget[]> {
  return combineLatest(widgetsSelector(store), lookupValuesSelector(store, 'lkpWidgets'), windowHeightSelector(store), windowWidthSelector(store), (widgets, lkp, h, w) => {
    const userWidgets = widgets.asArray.map(x => build(Widget, x, {
      label: build(LookupValue, lkp.find(y => y.name === x.name)).label,
      left: x.offsetX * w,
      top: x.offsetY * h,
      heightPx: x.height === 0 ? 400 : x.height * h,
      widthPx: x.width === 0 ? 500 : x.width * w
    }));
    return userWidgets.length > 0 ? userWidgets : [
      build(Widget, {
        name: 'routings-map',
        label: build(LookupValue, lkp.find(y => y.name === 'routings-map')).label,
        left: .1 * w,
        top: .15 * h,
        offsetY: .1,
        offsetX: .15,
        height: .7,
        width: .8,
        heightPx: .7 * h,
        widthPx: .8 * w
      })
    ];
  });
}

export function widgetsLookupSelector(store: Store<any>): Observable<Widget[]> {
  return combineLatest(lookupValuesSelector(store, 'lkpWidgets'), userWidgetsSelector(store), (lkpWidgets, userWidgets) => {
    console.dir(userWidgets);
    return lkpWidgets.map(x => build(Widget, userWidgets.find(w => w.name === x.name), {
      label: x.label,
      name: x.name
    })).sort((a, b) => compareNumbers(-a.id, -b.id));
  });
}

export function accessCodeSelector(store: Store<any>): Observable<string> {
  return store.select('accessCode');
}
