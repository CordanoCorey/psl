import { NgModule } from '@angular/core';

import { DealersRoutingModule } from './dealers-routing.module';
import { DealersComponent } from './dealers.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [DealersComponent],
  imports: [
    SharedModule,
    DealersRoutingModule
  ]
})
export class DealersModule { }
