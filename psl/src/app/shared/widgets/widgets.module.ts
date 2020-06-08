import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { WidgetComponent } from './widget/widget.component';
import { WidgetsMenuComponent } from './widgets-menu/widgets-menu.component';

@NgModule({
  declarations: [
    WidgetComponent,
    WidgetsMenuComponent
  ],
  imports: [
    CommonModule,
    DragDropModule,
    MatButtonModule,
    MatIconModule
  ],
  exports: [
    WidgetComponent,
    WidgetsMenuComponent,
    DragDropModule
  ]
})
export class WidgetsModule { }
