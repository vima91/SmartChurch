import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './settings.component';
import { LayoutsModule } from '../../layouts/layouts.module';
import { CountryComponent } from './country/country.component';
import { GradeComponent } from './grade/grade.component';
import { ServiceTypeComponent } from './service-type/service-type.component';
import { BaptismTypeComponent } from './baptism-type/baptism-type.component';
import { ExpenseTypeComponent } from './expense-type/expense-type.component';
import { MarriageTypeComponent } from './marriage-type/marriage-type.component';
import { ReligiousTypeComponent } from './religious-type/religious-type.component';
import { AppSettingsComponent } from './app-settings/app-settings.component';
import { MaterialModule } from '../../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ItemsListComponent } from './components/items-list/items-list.component';
import { ItemDetailsComponent } from './components/item-details/item-details.component';
import { MaritalStatusComponent } from './marital-status/marital-status.component';
import { CountryDetailsComponent } from './country/country-details/country-details.component';
import { CountryListComponent } from './country/country-list/country-list.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    LayoutsModule,
    FormsModule,
    ReactiveFormsModule,
    SettingsRoutingModule
  ],
  declarations: [
    SettingsComponent,
    CountryComponent,
    CountryListComponent,
    CountryDetailsComponent,
    GradeComponent,
    ServiceTypeComponent,
    BaptismTypeComponent,
    ExpenseTypeComponent,
    MarriageTypeComponent,
    ReligiousTypeComponent,
    AppSettingsComponent,
    MaritalStatusComponent,
    ItemsListComponent,
    ItemDetailsComponent
  ]
})
export class SettingsModule {
}
