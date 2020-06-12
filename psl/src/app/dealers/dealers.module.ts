import { NgModule } from '@angular/core';

import { DealersRoutingModule } from './dealers-routing.module';
import { DealersComponent } from './dealers.component';
import { SharedModule } from '../shared/shared.module';
import { DealersGridComponent } from './dealers-grid/dealers-grid.component';
import { DealerComponent } from './dealer/dealer.component';


@NgModule({
  declarations: [DealersComponent, DealersGridComponent, DealerComponent],
  imports: [
    SharedModule,
    DealersRoutingModule
  ]
})
export class DealersModule { }
