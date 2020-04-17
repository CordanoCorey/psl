import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, InjectionToken } from '@angular/core';
import {
  authTokenSelector,
  EffectsModule,
  ErrorsModule,
  EventEffects,
  EventsModule,
  LookupModule,
  HttpEffects,
  HttpModule,
  RouterEffects,
  RouterModule,
  StorageEffects,
  StorageModule,
  MessagesEffects,
  apiBaseUrlSelector
} from '@caiu/library';
import { ActionReducerMap, StoreModule } from '@ngrx/store';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReducersService } from './reducers.service';
import { SharedModule } from './shared/shared.module';
import { CurrentUserEffects } from './shared/effects';

export const REDUCER_TOKEN = new InjectionToken<ActionReducerMap<any>>('Registered Reducers');

export function getReducers(reducersService: ReducersService) {
  return reducersService.getReducers();
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    EffectsModule.forRoot([
      CurrentUserEffects,
      EventEffects,
      HttpEffects,
      MessagesEffects,
      RouterEffects,
      StorageEffects
    ]),
    ErrorsModule.forRoot(),
    EventsModule,
    HttpModule.forRoot(apiBaseUrlSelector, authTokenSelector),
    LookupModule.forRoot(),
    RouterModule.forRoot(),
    StorageModule.forRoot('AMSuite'),
    StoreModule.forRoot(REDUCER_TOKEN, {
      initialState: {},
      runtimeChecks: {
        strictStateImmutability: false,
        strictActionImmutability: false,
      }
    }),
    SharedModule,
  ],
  providers: [
    {
      provide: REDUCER_TOKEN,
      deps: [ReducersService],
      useFactory: getReducers
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
