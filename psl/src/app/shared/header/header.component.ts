import { Component, OnInit } from '@angular/core';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';

import { CurrentUserActions } from '../actions';

@Component({
  selector: 'psl-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends SmartComponent implements OnInit {

  constructor(public store: Store<any>) {
    super(store);
  }

  ngOnInit(): void {
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

}
