import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SettingsComponent } from './settings.component';
import { AuthGuard } from '../../guards/auth.guard';
import { AppSettingsComponent } from './app-settings/app-settings.component';
import { CountryComponent } from './country/country.component';
import { GradeComponent } from './grade/grade.component';
import { ServiceTypeComponent } from './service-type/service-type.component';
import { ReligiousTypeComponent } from './religious-type/religious-type.component';
import { MarriageTypeComponent } from './marriage-type/marriage-type.component';
import { ExpenseTypeComponent } from './expense-type/expense-type.component';
import { BaptismTypeComponent } from './baptism-type/baptism-type.component';
import { MaritalStatusComponent } from './marital-status/marital-status.component';

const routes: Routes = [
  { path: '', component: SettingsComponent , canActivate: [AuthGuard],
    children: [
      { path: '', component: CountryComponent },
      { path: 'country', component: CountryComponent },
      { path: 'app-settings', component: AppSettingsComponent },
      { path: 'baptism-type', component: BaptismTypeComponent },
      { path: 'expense-type', component: ExpenseTypeComponent },
      { path: 'marriage-type', component: MarriageTypeComponent },
      { path: 'marital-status', component: MaritalStatusComponent },
      { path: 'religious-type', component: ReligiousTypeComponent },
      { path: 'service-type', component: ServiceTypeComponent },
      { path: 'grade', component: GradeComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
