import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../guards/auth.guard';
import { AccountingListsComponent } from './accounting-lists/accounting-lists.component';
import { AccountingComponent } from './accounting.component';

const routes: Routes = [
  {
    path: '',
    component: AccountingComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: AccountingListsComponent, canActivate: [AuthGuard] }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountingRoutingModule { }
