import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions, windowHeightSelector, windowWidthSelector, build, Image, compareNumbers } from '@caiu/library';
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
  height = 0;
  width = 0;
  lkpWidgets$: Observable<Widget[]>;
  _resizing = false;
  scrollTop = 0;
  userId = 0;
  userId$: Observable<number>;
  _widgets: Widget[] = [];
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

  get hasDefaultWidgets(): boolean {
    return this.widgets.findIndex(x => x.id === 0) !== -1;
  }

  get overflowedX(): boolean {
    return this.width > this.windowWidth;
  }

  get overflowedY(): boolean {
    return this.height > this.windowHeight;
  }

  get scrollbarWidth(): number {
    return this.overflowedY ? 30 : 0;
  }

  set widgets(value: Widget[]) {
    this._widgets = value;
    this.height = Math.max(...[...value.map(x => x.heightPx + x.top + 100), this.windowHeight]);
    this.width = Math.max(...[...value.map(x => x.widthPx + x.left), this.windowWidth]);
  }

  get widgets(): Widget[] {
    return this._widgets;
  }

  get nextZIndex(): number {
    return Math.max(...this.widgets.map(x => x.zIndex), 0) + 1;
  }

  get focusedId(): number {
    return build(Widget, this.widgets.sort((a, b) => compareNumbers(-a.zIndex, -b.zIndex)).find((x, i) => i === 0)).id;
  }

  ngOnInit(): void {
    this.onInit();
    this.sync(['userId', 'windowHeight', 'windowWidth', 'widgets']);
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

  onDelete(e: any) {
    if (e.id !== 0) {
      this.deleteWidget(e.id);
    } else {
      this.saveUserWidgets(this.widgets.filter(x => x.name !== e.key));
    }
  }

  onDrop(widget: Widget, d: Distance) {
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
    if (this.hasDefaultWidgets) {
      this.saveUserWidgets(this.widgets.map(x => x.name === w.name ? w : x));
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
    const w = build(Widget, widget, {
      top: e.top,
      left: e.left,
      offsetX,
      offsetY,
      width: e.widthPx / this.windowWidth,
      height: e.heightPx / this.windowHeight,
      zIndex: e.zIndex
    });
    if (this.hasDefaultWidgets) {
      this.saveUserWidgets(this.widgets.map(x => x.name === w.name ? w : x));
    } else {
      this.updateWidget(w);
    }
  }

  justifyLeft() {

  }

  saveUserWidgets(e: Widget[]) {
    this.dispatch(HttpActions.post(`widgets/user`, e, WidgetsActions.POST));
  }

  addWidget(e: Widget) {
    this.dispatch(HttpActions.post(`widgets`, e, WidgetsActions.POST, WidgetsActions.POST_ERROR));
  }

  deleteWidget(e: number) {
    this.dispatch(HttpActions.delete(`widgets/${e}`, e, WidgetsActions.DELETE));
  }

  updateWidget(e: Widget) {
    this.dispatch(HttpActions.put(`widgets/${e.id}`, e, WidgetsActions.PUT));
  }

}
