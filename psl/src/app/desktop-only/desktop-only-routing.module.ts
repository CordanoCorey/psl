import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DesktopOnlyComponent } from './desktop-only.component';


const routes: Routes = [
  {
    path: '',
    component: DesktopOnlyComponent,
    data: { routeName: 'desktop-only', routeLabel: 'Desktop Only' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DesktopOnlyRoutingModule { }
