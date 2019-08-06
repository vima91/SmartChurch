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
import { ServiceLeaderListComponent } from './service-leader-list/service-leader-list.component';
import { ServiceSubscriptionListComponent } from './service-subscription-list/service-subscription-list.component';
import { ServiceSubscriptionEditComponent } from './components/service-subscription-edit/service-subscription-edit.component';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    ServicesRoutingModule
  ],
  entryComponents:[ServiceEditComponent, ServiceLeaderEditComponent,ServiceSubscriptionEditComponent],
  declarations: [ServicesComponent, ServiceEditComponent, ServiceLeaderEditComponent, ServiceListComponent, ServiceLeaderListComponent, ServiceSubscriptionListComponent, ServiceSubscriptionEditComponent]
})
export class ServicesModule { }
