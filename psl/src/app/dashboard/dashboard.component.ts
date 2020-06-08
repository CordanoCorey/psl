import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions, windowHeightSelector, windowWidthSelector, build, LookupValue, lookupValuesSelector, compareStrings, compareNumbers } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { WidgetsActions } from '../shared/actions';
import { Widget, Distance } from '../shared/models';
import { userWidgetsSelector, currentUserIdSelector, widgetsLookupSelector } from '../shared/selectors';

@Component({
  selector: 'psl-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends SmartComponent implements OnInit {

  lkpWidgets$: Observable<Widget[]>;
  _resizing = false;
  userId = 0;
  userId$: Observable<number>;
  widgets: Widget[] = [];
  widgets$: Observable<Widget[]>;
  windowHeight = 0;
  windowHeight$: Observable<number>;
  windowWidth = 0;
  windowWidth$: Observable<number>;

  constructor(public store: Store<any>) {
    super(store);
    this.lkpWidgets$ = widgetsLookupSelector(store);
    this.userId$ = currentUserIdSelector(store);
    this.widgets$ = userWidgetsSelector(store);
    this.windowHeight$ = windowHeightSelector(store);
    this.windowWidth$ = windowWidthSelector(store);
  }

  get nextZIndex(): number {
    return Math.max(...this.widgets.map(x => x.zIndex), 0) + 1;
  }

  get focusedId(): number {
    return build(Widget, this.widgets.sort((a, b) => compareNumbers(-a.zIndex, -b.zIndex)).find((x, i) => i === 0)).id;
  }

  ngOnInit(): void {
    this.onInit();
    this.sync(['userId', 'widgets', 'windowHeight', 'windowWidth']);
  }

  onAdd(e: string) {
    this.addWidget(build(Widget, {
      name: e,
      userId: this.userId,
      offsetX: .25,
      offsetY: .25,
      width: .5,
      height: .5,
      zIndex: this.nextZIndex
    }));
  }

  onDrop(widget: Widget, d: Distance) {
    console.dir(widget);
    const top = widget.top + d.y;
    const left = widget.left + d.x;
    const offsetY = top / this.windowHeight;
    const offsetX = left / this.windowWidth;
    const w = build(Widget, widget, {
      top,
      left,
      offsetX,
      offsetY,
      zIndex: d.zIndex,
      userId: this.userId
    });
    if (widget.id === 0) {
      this.addWidget(w);
    } else {
      this.updateWidget(w);
    }
  }

  onFocus(e: number) {
    this.updateWidget(build(Widget, this.widgets.find(x => x.id === e), { zIndex: this.nextZIndex }));
  }

  onResize(widget: Widget, e: any) {
    const offsetY = e.top / this.windowHeight;
    const offsetX = e.left / this.windowWidth;
    this.updateWidget(build(Widget, widget, {
      top: e.top,
      left: e.left,
      offsetX,
      offsetY,
      width: e.widthPx / this.windowWidth,
      height: e.heightPx / this.windowHeight,
      zIndex: e.zIndex
    }));
  }

  justifyLeft() {

  }

  addWidget(e: Widget) {
    this.dispatch(HttpActions.post(`widgets`, e, WidgetsActions.POST, WidgetsActions.POST));
  }

  deleteWidget(e: number) {
    this.dispatch(HttpActions.delete(`widgets/${e}`, e, WidgetsActions.DELETE));
  }

  updateWidget(e: Widget) {
    this.dispatch(HttpActions.put(`widgets/${e.id}`, e, WidgetsActions.PUT));
  }

}
