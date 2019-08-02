import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServicesComponent } from './services.component';
import { AuthGuard } from '../../guards/auth.guard';
import { ServiceListComponent } from './service-list/service-list.component';


const routes: Routes = [
  {
    path: '',
    component: ServicesComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: ServiceListComponent, canActivate: [AuthGuard] }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicesRoutingModule { }
