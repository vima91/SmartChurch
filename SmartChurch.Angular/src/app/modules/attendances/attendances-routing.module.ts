import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../guards/auth.guard';
import { AttendancesComponent } from './attendances.component';
import { AttendancesListComponent } from './attendances-list/attendances-list.component';
import { AttendancesEditComponent } from './components/attendances-edit/attendances-edit.component';

const routes: Routes = [
  {
    path: '',
    component: AttendancesComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: AttendancesListComponent, canActivate: [AuthGuard] },
      { path: 'edit/:id/:name', component: AttendancesEditComponent, canActivate: [AuthGuard] }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AttendancesRoutingModule { }
