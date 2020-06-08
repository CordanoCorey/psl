import { NgModule } from '@angular/core';

import { CarriersRoutingModule } from './carriers-routing.module';
import { CarriersComponent } from './carriers.component';
import { SharedModule } from '../shared/shared.module';
import { CarriersGridComponent } from './carriers-grid/carriers-grid.component';


@NgModule({
  declarations: [CarriersComponent, CarriersGridComponent],
  imports: [
    SharedModule,
    CarriersRoutingModule
  ]
})
export class CarriersModule { }
