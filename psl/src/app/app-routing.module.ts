import { NgModule, Injectable } from '@angular/core';
import { Routes, RouterModule, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { authenticatedSelector, accessCodeSelector } from './shared/selectors';
import { RouterService } from '@caiu/library';

@Injectable()
export class AuthenticatedGuard implements CanActivate {

  accessCode = '';
  authenticated = false;

  constructor(public store: Store<any>, public routerService: RouterService) {
    authenticatedSelector(store).subscribe(x => {
      this.authenticated = x;
    });
    accessCodeSelector(store).subscribe(x => {
      this.accessCode = x;
    });
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    if (!this.authenticated) {
      this.routerService.navigate([`/login/${this.accessCode}`]);
    }
    return true;
  }

}

const routes: Routes = [{
  path: '',
  children: [
    { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
    {
      path: 'access-denied',
      loadChildren: () => import('./access-denied/access-denied.module').then(m => m.AccessDeniedModule)
    },
    {
      path: 'desktop-only',
      loadChildren: () => import('./desktop-only/desktop-only.module').then(m => m.DesktopOnlyModule)
    },
    {
      path: 'accounts',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./accounts/accounts.module').then(m => m.AccountsModule)
    },
    {
      path: 'dashboard',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
    },
    {
      path: 'login/:accessCode',
      loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
    },
    {
      path: 'login',
      redirectTo: 'access-denied'
    },
    {
      path: 'reports',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./reports/reports.module').then(m => m.ReportsModule)
    },
    {
      path: 'users',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./users/users.module').then(m => m.UsersModule)
    },
    {
      path: 'carriers',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./carriers/carriers.module').then(m => m.CarriersModule)
    },
    {
      path: 'dealers',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./dealers/dealers.module').then(m => m.DealersModule)
    },
    {
      path: 'processes',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./processes/processes.module').then(m => m.ProcessesModule)
    },
    {
      path: 'orders',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
    },
    {
      path: 'products',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)
    },
    {
      path: 'routings',
      canActivate: [AuthenticatedGuard],
      loadChildren: () => import('./routings/routings.module').then(m => m.RoutingsModule)
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthenticatedGuard]
})
export class AppRoutingModule { }
