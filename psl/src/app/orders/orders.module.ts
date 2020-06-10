import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersComponent } from './orders.component';
import { OrdersGridComponent } from './orders-grid/orders-grid.component';
import { OrderStatusesComponent } from './order-statuses/order-statuses.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    OrdersComponent,
    OrdersGridComponent,
    OrderStatusesComponent
  ],
  imports: [
    SharedModule,
    OrdersRoutingModule
  ],
  exports: [
    OrdersGridComponent,
    OrderStatusesComponent
  ]
})
export class OrdersModule { }
