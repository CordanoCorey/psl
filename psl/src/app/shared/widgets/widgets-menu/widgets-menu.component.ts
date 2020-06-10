import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DumbComponent } from '@caiu/library';

import { Widget } from '../../models';

@Component({
  selector: 'psl-widgets-menu',
  templateUrl: './widgets-menu.component.html',
  styleUrls: ['./widgets-menu.component.scss']
})
export class WidgetsMenuComponent extends DumbComponent implements OnInit {

  @Input() increment = 5;
  @Input() widgets: Widget[] = [];
  @Output() add = new EventEmitter<string>();
  @Output() remove = new EventEmitter<number>();
  index = 0;

  constructor() {
    super();
  }

  get showBack(): boolean {
    return this.index !== 0;
  }

  get showNext(): boolean {
    return this.widgets.length > this.index + 5;
  }

  get totalAfter(): number {
    return this.widgets.length - (this.index + 5);
  }

  get visibleItems(): Widget[] {
    return this.widgets.filter((x, i) => i >= this.index && i < this.index + 5);
  }

  ngOnInit(): void {
  }

  back() {
    this.index = Math.max(this.index - this.increment, 0);
  }

  next() {
    console.log(this.totalAfter);
    this.index = this.totalAfter < this.increment ? this.index + this.totalAfter : this.index + this.increment;
    console.log(this.index);
  }

}
