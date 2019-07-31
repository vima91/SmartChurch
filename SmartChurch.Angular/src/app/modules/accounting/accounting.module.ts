import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountingRoutingModule } from './accounting-routing.module';
import { AccountingComponent } from './accounting.component';
import { LayoutsModule } from '../../layouts/layouts.module';
import { AccountingListsComponent } from './accounting-lists/accounting-lists.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { DepoisteToBankComponent } from './components/depoiste-to-bank/depoiste-to-bank.component';
import { WithdrawFromBankComponent } from './components/withdraw-from-bank/withdraw-from-bank.component';
import { CreateExpenseComponent } from './components/create-expense/create-expense.component';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    AccountingRoutingModule
  ],
  entryComponents: [DepoisteToBankComponent,WithdrawFromBankComponent,CreateExpenseComponent],
  declarations: [AccountingComponent, AccountingListsComponent, DepoisteToBankComponent, WithdrawFromBankComponent, CreateExpenseComponent]
})
export class AccountingModule { }
