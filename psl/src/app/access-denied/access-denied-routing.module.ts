import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccessDeniedComponent } from './access-denied.component';

const routes: Routes = [
  {
    path: '',
    component: AccessDeniedComponent,
    data: { routeName: 'access-denied', routeLabel: 'Access Denied' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessDeniedRoutingModule { }
