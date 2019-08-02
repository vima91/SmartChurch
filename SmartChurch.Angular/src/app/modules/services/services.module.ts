import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServicesRoutingModule } from './services-routing.module';
import { ServicesComponent } from './services.component';
import { LayoutsModule } from '../../layouts/layouts.module';
import { ServiceEditComponent } from './components/service-edit/service-edit.component';
import { ServiceLeaderEditComponent } from './components/service-leader-edit/service-leader-edit.component';
import { ServiceListComponent } from './service-list/service-list.component';
import { MaterialModule } from 'src/app/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    ServicesRoutingModule
  ],
  entryComponents:[ServiceEditComponent, ServiceLeaderEditComponent],
  declarations: [ServicesComponent, ServiceEditComponent, ServiceLeaderEditComponent, ServiceListComponent]
})
export class ServicesModule { }
