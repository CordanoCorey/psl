import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CarriersComponent } from './carriers.component';
import { CarrierComponent } from './carrier/carrier.component';

const routes: Routes = [
  {
    path: ':carrierId',
    component: CarrierComponent,
    data: { routeName: 'carrier', routeLabel: 'Carrier' }
  },
  {
    path: '',
    component: CarriersComponent,
    data: { routeName: 'carriers', routeLabel: 'Carriers' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarriersRoutingModule { }
