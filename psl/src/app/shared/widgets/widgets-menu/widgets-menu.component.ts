import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DumbComponent } from '@caiu/library';

import { Widget } from '../../models';

@Component({
  selector: 'psl-widgets-menu',
  templateUrl: './widgets-menu.component.html',
  styleUrls: ['./widgets-menu.component.scss']
})
export class WidgetsMenuComponent extends DumbComponent implements OnInit {

  @Input() widgets: Widget[] = [];
  @Output() add = new EventEmitter<string>();
  @Output() remove = new EventEmitter<number>();

  constructor() {
    super();
  }

  ngOnInit(): void {
  }

}
