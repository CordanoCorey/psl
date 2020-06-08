import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DumbComponent } from '@caiu/library';
import { CdkDragEnd } from '@angular/cdk/drag-drop';

@Component({
  selector: 'psl-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.scss']
})
export class WidgetComponent extends DumbComponent implements OnInit {

  @Input() borderWidth = 10;
  @Input() heading = '';
  @Input() id = 0;
  @Input() isFocused = false;
  @Input() widthPx = 600;
  @Input() heightPx = 300;
  @Input() top = 0;
  @Input() left = 0;
  @Input() startX = 0;
  @Input() startY = 0;
  @Input() zIndex = 1;
  @Input() nextZIndex = 1;
  @Output() dropped = new EventEmitter();
  @Output() focused = new EventEmitter<number>();
  @Output() remove = new EventEmitter<number>();
  @Output() resized = new EventEmitter();
  cursorStyle = 'move';
  dragging = false;
  hovering = false;
  mouseBottom = false;
  mouseLeft = false;
  mouseRight = false;
  mouseTop = false;
  pageX = 0;
  pageY = 0;
  _resizable = false;
  resizing = false;
  wrapperWidth = 55;

  constructor() {
    super();
  }

  set resizable(value: boolean) {
    this._resizable = value;
  }

  get resizable(): boolean {
    return this._resizable;
  }

  ngOnInit(): void {
  }

  onDrag() {
    this.zIndex = this.nextZIndex;
    this.dragging = true;
  }

  onDrop(e: CdkDragEnd) {
    this.dropped.emit(Object.assign({}, e.distance, { zIndex: this.zIndex }));
    setTimeout(() => {
      this.dragging = false;
    });
  }

  onFocus() {
    if (!this.dragging && !this.resizing) {
      this.zIndex = this.nextZIndex;
      this.focused.emit(this.id);
    }
  }

  onMousedown(e) {
    if (this.resizable) {
      this.resizing = true;
    }
  }

  onMousemove(e) {
    this.pageX = e.pageX;
    this.pageY = e.pageY;
    if (this.resizing) {
      this.onResize();
    } else {
      this.refreshCursorStyle();
    }
  }

  onMouseout(e) {
    this.onMouseup(e);
    this.hovering = false;
  }

  onMouseup(e) {
    if (this.resizing) {
      this.resized.emit({
        top: this.top,
        left: this.left,
        heightPx: this.heightPx,
        widthPx: this.widthPx,
        zIndex: this.nextZIndex
      });
    }
    setTimeout(() => {
      this.resizing = false;
    });
  }

  onResize() {
    const dY = this.top - (this.pageY - this.startY);
    const dX = this.left - (this.pageX - this.startX);
    if (this.mouseTop) {
      this.top = this.top - dY;
      this.heightPx = this.heightPx + dY;
    }
    if (this.mouseBottom) {
      this.heightPx = this.pageY - this.startY - this.top;
    }
    if (this.mouseLeft) {
      this.left = this.left - dX;
      this.widthPx = this.widthPx + dX;
    }
    if (this.mouseRight) {
      this.widthPx = this.pageX - this.startX - this.left;
    }
  }

  refreshCursorStyle() {
    this.mouseLeft = this.left + this.startX - this.pageX >= 0
      && this.left + this.startX - this.pageX <= this.borderWidth;
    this.mouseRight = this.pageX - (this.widthPx + this.left + this.startX) >= 0
      && this.pageX - (this.widthPx + this.left + this.startX) <= this.borderWidth;
    this.mouseTop = this.top + this.startY - this.pageY >= 0
      && this.top + this.startY - this.pageY <= this.borderWidth;
    this.mouseBottom = this.pageY - (this.heightPx + this.top + this.startY) >= 0
      && this.pageY - (this.heightPx + this.top + this.startY) <= this.borderWidth;
    if (this.mouseTop && this.mouseLeft) { // top-left
      this.cursorStyle = 'nw-resize';
    } else if (this.mouseBottom && this.mouseRight) { // bottom-right
      this.cursorStyle = 'se-resize';
    } else if (this.mouseBottom && this.mouseLeft) { // bottom-left
      this.cursorStyle = 'sw-resize';
    } else if (this.mouseTop && this.mouseRight) { // top-right
      this.cursorStyle = 'ne-resize';
    } else if (this.mouseTop) { // top
      this.cursorStyle = 'n-resize';
    } else if (this.mouseBottom) { // bottom
      this.cursorStyle = 's-resize';
    } else if (this.mouseLeft) { // left
      this.cursorStyle = 'w-resize';
    } else if (this.mouseRight) { // right
      this.cursorStyle = 'e-resize';
    } else {
      this.cursorStyle = 'move';
    }
    this.resizable = this.cursorStyle !== 'move';
  }

}
