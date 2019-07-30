import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PeopleComponent } from './people.component';
import { AuthGuard } from '../../guards/auth.guard';
import { PeopleListComponent } from './people-list/people-list.component';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { CreatePersonComponent } from './create-person/create-person.component';

const routes: Routes = [
  {
    path: '', component: PeopleComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: PeopleListComponent },
      { path: 'person-details/:id', component: PersonDetailsComponent },
      { path: 'create-person', component: CreatePersonComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PeopleRoutingModule { }
