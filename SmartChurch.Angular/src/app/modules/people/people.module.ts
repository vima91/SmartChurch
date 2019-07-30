import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '../../material.module';
import { LayoutsModule } from '../../layouts/layouts.module';
import { PeopleRoutingModule } from './people-routing.module';
import { PeopleComponent } from './people.component';
import { PeopleListComponent } from './people-list/people-list.component';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { CreatePersonComponent } from './create-person/create-person.component';
import { PersonViewComponent } from './components/person-view/person-view.component';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    PeopleRoutingModule
  ],
  declarations: [PeopleComponent, PeopleListComponent, PersonDetailsComponent, CreatePersonComponent, PersonViewComponent]
})
export class PeopleModule { }
