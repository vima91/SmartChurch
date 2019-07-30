import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RemindersRoutingModule } from './reminders-routing.module';
import { RemindersComponent } from './reminders.component';
import { LayoutsModule } from '../../layouts/layouts.module';
import { RemindersListsComponent } from './reminders-lists/reminders-lists.component';
import {MaterialModule} from '../../material.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CountoModule} from 'angular2-counto';
import { RemindersBirthdayListComponent } from './components/reminders-birthday-list/reminders-birthday-list.component';
import { RemindersVisitListComponent } from './components/reminders-visit-list/reminders-visit-list.component';
import { RemindersMarriageAnniversaryListComponent } from './components/reminders-marriage-anniversary-list/reminders-marriage-anniversary-list.component';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    RemindersRoutingModule,
    CountoModule
  ],
  declarations: [RemindersComponent, RemindersListsComponent, RemindersBirthdayListComponent, RemindersVisitListComponent, RemindersMarriageAnniversaryListComponent]
})
export class RemindersModule { }
