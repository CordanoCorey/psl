import { NgModule, Injectable } from '@angular/core';
import { Routes, RouterModule, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { accessGrantedSelector } from './shared/selectors';

@Injectable()
export class AccessGrantedGuard implements CanActivateChild {

  accessGranted = true;

  constructor(public store: Store<any>) {
    // accessGrantedSelector(store).subscribe(x => {
    //   this.accessGranted = x;
    // });
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    return this.accessGranted;
  }

}

const routes: Routes = [{
  path: '',
  canActivateChild: [AccessGrantedGuard],
  children: [
    { path: '', pathMatch: 'full', redirectTo: 'login' },
    {
      path: 'accounts',
      loadChildren: () => import('./accounts/accounts.module').then(m => m.AccountsModule)
    },
    {
      path: 'dashboard',
      loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
    },
    {
      path: 'login',
      loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
    },
    {
      path: 'reports',
      loadChildren: () => import('./reports/reports.module').then(m => m.ReportsModule)
    },
    {
      path: 'users',
      loadChildren: () => import('./users/users.module').then(m => m.UsersModule)
    },
    {
      path: 'carriers',
      loadChildren: () => import('./carriers/carriers.module').then(m => m.CarriersModule)
    },
    {
      path: 'dealers',
      loadChildren: () => import('./dealers/dealers.module').then(m => m.DealersModule)
    },
    {
      path: 'products',
      loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)
    },
    {
      path: 'routings',
      loadChildren: () => import('./routings/routings.module').then(m => m.RoutingsModule)
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AccessGrantedGuard]
})
export class AppRoutingModule { }
