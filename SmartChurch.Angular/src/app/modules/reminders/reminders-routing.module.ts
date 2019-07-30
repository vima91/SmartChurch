import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../guards/auth.guard';
import { RemindersComponent } from './reminders.component';
import { RemindersListsComponent } from './reminders-lists/reminders-lists.component';
import { RemindersBirthdayListComponent } from './components/reminders-birthday-list/reminders-birthday-list.component';
import { RemindersVisitListComponent } from './components/reminders-visit-list/reminders-visit-list.component';
import { RemindersMarriageAnniversaryListComponent } from './components/reminders-marriage-anniversary-list/reminders-marriage-anniversary-list.component';

const routes: Routes = [
  {
    path: '',
    component: RemindersComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: RemindersListsComponent, canActivate: [AuthGuard] },
      { path: 'birthday-reminders', component: RemindersBirthdayListComponent, canActivate: [AuthGuard] },
      { path: 'visit-reminders', component: RemindersVisitListComponent, canActivate: [AuthGuard] },
      { path: 'marriage-anniversary-reminders', component: RemindersMarriageAnniversaryListComponent, canActivate: [AuthGuard] }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RemindersRoutingModule {
}
