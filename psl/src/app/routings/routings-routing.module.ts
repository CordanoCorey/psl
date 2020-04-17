import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RoutingsComponent } from './routings.component';

const routes: Routes = [
  {
    path: '',
    component: RoutingsComponent,
    data: { routeName: 'routings', routeLabel: 'Routings' }
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoutingsRoutingModule { }
