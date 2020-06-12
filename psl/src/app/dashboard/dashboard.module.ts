import { NgModule } from '@angular/core';
import { WallpaperModule } from '@caiu/library';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { CarriersModule } from '../carriers/carriers.module';
import { OrdersModule } from '../orders/orders.module';
import { ProductsModule } from '../products/products.module';
import { RoutingsModule } from '../routings/routings.module';
import { SharedModule } from '../shared/shared.module';
import { WidgetsModule } from '../shared/widgets/widgets.module';


@NgModule({
  declarations: [DashboardComponent],
  imports: [
    SharedModule,
    DashboardRoutingModule,
    CarriersModule,
    OrdersModule,
    ProductsModule,
    RoutingsModule,
    WidgetsModule
  ]
})
export class DashboardModule { }
