import { NgModule } from '@angular/core';

import { CarriersRoutingModule } from './carriers-routing.module';
import { CarriersComponent } from './carriers.component';
import { SharedModule } from '../shared/shared.module';
import { CarriersGridComponent } from './carriers-grid/carriers-grid.component';
import { CarriersMarketShareComponent } from './carriers-market-share/carriers-market-share.component';


@NgModule({
  declarations: [
    CarriersComponent, 
    CarriersGridComponent, 
    CarriersMarketShareComponent
    ],
  imports: [
    SharedModule,
    CarriersRoutingModule
  ],
  exports: [
    CarriersGridComponent,
    CarriersMarketShareComponent
  ]
})
export class CarriersModule { }
