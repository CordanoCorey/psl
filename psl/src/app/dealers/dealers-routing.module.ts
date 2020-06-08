import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DealersComponent } from './dealers.component';


const routes: Routes = [
  {
    path: '',
    component: DealersComponent,
    data: { routeName: 'dealers', routeLabel: 'Dealers' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DealersRoutingModule { }
