import { NgModule } from '@angular/core';

import { ProcessesRoutingModule } from './processes-routing.module';
import { ProcessesComponent } from './processes.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [ProcessesComponent],
  imports: [
    SharedModule,
    ProcessesRoutingModule
  ]
})
export class ProcessesModule { }
