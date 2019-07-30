import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountingRoutingModule } from './accounting-routing.module';
import { AccountingComponent } from './accounting.component';
import { LayoutsModule } from '../../layouts/layouts.module';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    AccountingRoutingModule
  ],
  declarations: [AccountingComponent]
})
export class AccountingModule { }
