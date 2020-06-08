import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { RoutingsQuery } from './routings.model';

@Component({
  selector: 'psl-routings',
  templateUrl: './routings.component.html',
  styleUrls: ['./routings.component.scss']
})
export class RoutingsComponent extends SmartComponent implements OnInit {

  @Control(RoutingsQuery) form: FormGroup;

  constructor(public store: Store<any>) {
    super(store);
  }

  ngOnInit(): void {
  }

}
