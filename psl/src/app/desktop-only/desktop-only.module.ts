import { NgModule } from '@angular/core';

import { DesktopOnlyRoutingModule } from './desktop-only-routing.module';
import { DesktopOnlyComponent } from './desktop-only.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [DesktopOnlyComponent],
  imports: [
    SharedModule,
    DesktopOnlyRoutingModule
  ]
})
export class DesktopOnlyModule { }
