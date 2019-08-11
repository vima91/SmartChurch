import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AttendancesComponent } from './attendances.component';
import { AttendancesListComponent } from './attendances-list/attendances-list.component';
import { LayoutsModule } from 'src/app/layouts/layouts.module';
import { MaterialModule } from 'src/app/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AttendancesRoutingModule } from './attendances-routing.module';
import { AttendancesEditComponent } from './components/attendances-edit/attendances-edit.component';

@NgModule({
  imports: [
    CommonModule,
    LayoutsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    AttendancesRoutingModule
  ],
  entryComponents: [],
  declarations: [AttendancesComponent, AttendancesListComponent, AttendancesEditComponent]
})

export class AttendancesModule { }
