import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServicesRoutingModule } from './services-routing.module';
import { ServicesComponent } from './services.component';
import { LayoutsModule } from '../../layouts/layouts.module';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    ServicesRoutingModule
  ],
  declarations: [ServicesComponent]
})
export class ServicesModule { }
