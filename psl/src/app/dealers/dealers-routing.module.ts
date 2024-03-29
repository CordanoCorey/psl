import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DealersComponent } from './dealers.component';
import { DealerComponent } from './dealer/dealer.component';


const routes: Routes = [
  {
    path: ':dealerId',
    component: DealerComponent,
    data: { routeName: 'dealer', routeLabel: 'Dealer' }
  },
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
