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
  userId = 0;
  userId$: Observable<number>;
  _widgets: Widget[] = [];
  widgets$: Observable<Widget[]>;
  windowHeight = 0;
  windowHeight$: Observable<number>;
  windowWidth = 0;
  windowWidth$: Observable<number>;
  images: Image[] = [
    build(Image, {
      src: 'assets/products/category-4wd.png',
      height: 437,
      width: 779
    }),

    build(Image, {
      src: 'assets/products/category-compact.png',
      height: 437,
      width: 777
    }),

    build(Image, {
      src: 'assets/products/category-rowcrop.png',
      height: 541,
      width: 961
    }),

    build(Image, {
      src: 'assets/products/category-specialty.png',
      height: 437,
      width: 777
    }),
    build(Image, {
      src: 'assets/products/category-utility.png',
      height: 437,
      width: 777
    }),
    // build(Image, {
    //   src: 'assets/products/compact-1series.png',
    //   height: 304,
    //   width: 321
    // }),
    // build(Image, {
    //   src: 'assets/products/compact-2series.png',
    //   height: 304,
    //   width: 398
    // }),
    // build(Image, {
    //   src: 'assets/products/compact-3series.png',
    //   height: 279,
    //   width: 499
    // }),
    // build(Image, {
    //   src: 'assets/products/compact-4series.png',
    //   height: 295,
    //   width: 434
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5075GL.png',
    //   height: 655,
    //   width: 762
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5090EL.png',
    //   height: 621,
    //   width: 859
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5100ML.png',
    //   height: 567,
    //   width: 804
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5115ML.png',
    //   height: 653,
    //   width: 983
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5125ML.png',
    //   height: 556,
    //   width: 831
    // })
  ];

  constructor(public store: Store<any>) {
    super(store);
    this.lkpWidgets$ = widgetsLookupSelector(store);
    this.userId$ = currentUserIdSelector(store);
    this.widgets$ = userWidgetsSelector(store);
    this.windowHeight$ = windowHeightSelector(store);
    this.windowWidth$ = windowWidthSelector(store);
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
