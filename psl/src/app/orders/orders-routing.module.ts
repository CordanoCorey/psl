import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdersComponent } from './orders.component';


const routes: Routes = [{
  path: '',
  component: OrdersComponent,
  data: { routeName: 'orders', routeLabel: 'Orders' }
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
