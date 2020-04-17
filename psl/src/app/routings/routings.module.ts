import { NgModule } from '@angular/core';

import { RoutingsRoutingModule } from './routings-routing.module';
import { RoutingsComponent } from './routings.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [RoutingsComponent],
  imports: [
    SharedModule,
    RoutingsRoutingModule
  ]
})
export class RoutingsModule { }
