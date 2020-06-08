import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UsersComponent } from './users.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {
    path: ':userId',
    component: UserComponent,
    data: { routeName: 'user', routeLabel: 'User' }
  },
  {
    path: '',
    component: UsersComponent,
    data: { routeName: 'users', routeLabel: 'Users' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
