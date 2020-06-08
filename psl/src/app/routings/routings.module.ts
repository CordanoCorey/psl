import { NgModule } from '@angular/core';

import { RoutingsRoutingModule } from './routings-routing.module';
import { RoutingsComponent } from './routings.component';
import { SharedModule } from '../shared/shared.module';
import { RoutingsGridComponent } from './routings-grid/routings-grid.component';
import { RoutingsMapComponent } from './routings-map/routings-map.component';


@NgModule({
  declarations: [RoutingsComponent, RoutingsGridComponent, RoutingsMapComponent],
  imports: [
    SharedModule,
    RoutingsRoutingModule
  ],
  exports: [RoutingsGridComponent, RoutingsMapComponent]
})
export class RoutingsModule { }
