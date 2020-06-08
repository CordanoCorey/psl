import { NgModule } from '@angular/core';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { RoutingsModule } from '../routings/routings.module';
import { SharedModule } from '../shared/shared.module';
import { WidgetsModule } from '../shared/widgets/widgets.module';


@NgModule({
  declarations: [DashboardComponent],
  imports: [
    SharedModule,
    DashboardRoutingModule,
    RoutingsModule,
    WidgetsModule
  ]
})
export class DashboardModule { }
