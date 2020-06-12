import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RoutingsComponent } from './routings.component';
import { RoutingComponent } from './routing/routing.component';

const routes: Routes = [
  {
    path: ':routingId',
    component: RoutingComponent,
    data: { routeName: 'routing', routeLabel: 'Routing' }
  },
  {
    path: '',
    component: RoutingsComponent,
    data: { routeName: 'routings', routeLabel: 'Routings' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoutingsRoutingModule { }
