import { Component, OnInit, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatIconRegistry } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute } from '@angular/router';
import {
  build,
  WindowResize,
  LookupService,
  Lookup,
  SmartComponent,
  ConfigActions,
  WindowActions,
  RouterService,
  routeNameSelector,
  StorageService,
  messageSelector,
  AutoLogoutComponent,
  userLastActiveSelector,
  authenticatedSelector,
  HttpActions,
  RouterActions,
  urlPathSelector,
  SidenavActions,
  routeParamSelector
} from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';

import { CurrentUserActions, UsersActions, AccessGrantedActions } from './shared/actions';
import { CurrentUser } from './shared/models';
import { currentUserIdSelector } from './shared/selectors';
import { environment } from '../environments/environment';

var ACCESS_CODE = '';

@Component({
  selector: 'psl-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends SmartComponent implements OnInit {
  contestantId = 0;
  contestantId$: Observable<number>;
  errorMessage$: Observable<string>;
  lastActive = new Date();
  lastActive$: Observable<Date>;
  loggedIn = false;
  loggedIn$: Observable<boolean>;
  loggingOut = false;
  routeName = '';
  routeName$: Observable<string>;
  time;
  toast$: Observable<string>;
  urlPath = '';
  urlPath$: Observable<string>;
  userId$: Observable<number>;
  _userId = 0;

  constructor(
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    public store: Store<any>,
    public storage: StorageService,
    private routerService: RouterService,
    private router: Router,
    private route: ActivatedRoute,
    public lookup: LookupService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {
    super(store);
    // To avoid XSS attacks, the URL needs to be trusted from inside of your application.
    const avatarsSafeUrl = sanitizer.bypassSecurityTrustResourceUrl('./assets/avatars.svg');
    iconRegistry.addSvgIconSetInNamespace('avatars', avatarsSafeUrl);
    this.lastActive$ = userLastActiveSelector(store);
    this.loggedIn$ = authenticatedSelector(store);
    this.routeName$ = routeNameSelector(store);
    this.toast$ = messageSelector(store, 'TOASTS');
    this.errorMessage$ = messageSelector(store, 'ERRORS');
    this.userId$ = currentUserIdSelector(store);
    this.urlPath$ = urlPathSelector(store);
  }

  get errorMessageChanges(): Subscription {
    return this.errorMessage$.subscribe(x => {
      this.showErrorMessage(x);
    });
  }

  get localStorageActions(): string[] {
    return [...CurrentUserActions.ALL];
  }

  get localStorageMapper(): (s: any) => any {
    return state => {
      const currentUser = build(CurrentUser, state ? state.currentUser : {});
      return { currentUser };
    };
  }

  get lookupKeys(): string[] {
    return [];
  }

  get lookupValues(): Lookup[] {
    return [];
  }

  get sessionStorageActions(): string[] {
    return [];
  }

  get sessionStorageMapper(): (s: any) => any {
    return state => { };
  }

  get toastChanges(): Subscription {
    return this.toast$.subscribe(x => {
      this.openSnackBar(x);
    });
  }

  set userId(value: number) {
    if (value !== 0) {
      this.loadUserData();
    }
    this._userId = value;
  }

  get userId(): number {
    return this._userId;
  }

  ngOnInit() {
    this.storage.init(this.localStorageMapper, this.sessionStorageMapper, this.localStorageActions, this.sessionStorageActions);
    this.loadConfiguration();
    this.initStorage();
    this.initLookup();
    // setTimeout(() => {
    //   if (!this.time) {
    //     this.autoLogout();
    //   }
    // }, 1800000);
    this.sync(['lastActive', 'loggedIn', 'userId', 'urlPath']);
    this.addSubscription(this.toastChanges);
    this.addSubscription(this.errorMessageChanges);
    this.addSubscription(this.routeName$.subscribe(x => {
      this.routeName = x;
      if (x === 'dashboard') {
        this.openSidenav();
      } else {
        this.closeSidenav();
      }
    }));
    this.addSubscription(routeParamSelector(this.store, 'access_code').subscribe(code => {
      this.dispatch(AccessGrantedActions.setValue(code === ACCESS_CODE));
    }));
  }

  autoLogout() {
    if (this.loggedIn && !this.loggingOut) {
      this.loggingOut = true;
      this.openDialog(AutoLogoutComponent, {
        width: '600px'
      });
    }
  }

  closeDialog(result: any) {
    if (this.contestantId) {
      this.dispatch(RouterActions.navigate(`/${this.urlPath}`));
    }
    // if (this.loggingOut) {
    //   if (result) {
    //     this.logout();
    //   }
    //   this.loggingOut = false;
    // }
    super.closeDialog(result);
  }

  closeSidenav() {
    this.dispatch(SidenavActions.close());
  }

  openSidenav() {
    this.dispatch(SidenavActions.open());
  }

  getUsers() {
    this.dispatch(HttpActions.get(`users`, UsersActions.GET));
  }

  loadConfiguration() {
    this.store.dispatch(ConfigActions.initialize(environment));
  }

  initLookup() {
    this.lookup.load(this.lookupKeys, this.lookupValues);
  }

  initStorage() {
    this.storage.init(this.localStorageMapper, this.sessionStorageMapper, this.localStorageActions, this.sessionStorageActions);
  }

  loadUserData() {
    // this.getUsers();
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 3000
    });
  }

  showErrorMessage(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      verticalPosition: 'top',
      panelClass: 'snackbar-error'
    });
  }

  @HostListener('window:mousemove')
  resetTimer() {
    // clearTimeout(this.time);
    // this.time = setTimeout(() => {
    //   this.autoLogout();
    // }, 1800000); // logout after 30 minutes
  }

  @HostListener('window:load', ['$event'])
  onLoad(e: any) {
    const windowHeight = e && e.currentTarget && e.currentTarget.innerHeight ? e.currentTarget.innerHeight : 0;
    const windowWidth = e && e.currentTarget && e.currentTarget.innerWidth ? e.currentTarget.innerWidth : 0;
    this.dispatch(WindowActions.resize(build(WindowResize, { windowHeight, windowWidth })));
  }

  @HostListener('window:resize', ['$event'])
  onResize(e: any) {
    const windowHeight = e && e.currentTarget && e.currentTarget.innerHeight ? e.currentTarget.innerHeight : 0;
    const windowWidth = e && e.currentTarget && e.currentTarget.innerWidth ? e.currentTarget.innerWidth : 0;
    console.log(windowHeight, windowWidth);
    this.dispatch(WindowActions.resize(build(WindowResize, { windowHeight, windowWidth })));
  }

  @HostListener('window:orientationchange', ['$event'])
  onOrientationChange(e: any) {
    const windowHeight = e && e.currentTarget && e.currentTarget.innerHeight ? e.currentTarget.innerHeight : 0;
    const windowWidth = e && e.currentTarget && e.currentTarget.innerWidth ? e.currentTarget.innerWidth : 0;
    this.dispatch(WindowActions.resize(build(WindowResize, { windowHeight, windowWidth })));
  }
}
