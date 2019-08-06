import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServicesComponent } from './services.component';
import { AuthGuard } from '../../guards/auth.guard';
import { ServiceListComponent } from './service-list/service-list.component';
import { ServiceSubscriptionListComponent } from './service-subscription-list/service-subscription-list.component';
import { ServiceLeaderListComponent } from './service-leader-list/service-leader-list.component';


const routes: Routes = [
  {
    path: '',
    component: ServicesComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: ServiceListComponent},
      { path: 'leaders/:id/:name', component: ServiceLeaderListComponent },
      { path: 'subscriptions/:id/:name', component: ServiceSubscriptionListComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicesRoutingModule { }
