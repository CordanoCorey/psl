import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProcessesRoutingModule } from './processes-routing.module';
import { ProcessesComponent } from './processes.component';


@NgModule({
  declarations: [ProcessesComponent],
  imports: [
    CommonModule,
    ProcessesRoutingModule
  ]
})
export class ProcessesModule { }
