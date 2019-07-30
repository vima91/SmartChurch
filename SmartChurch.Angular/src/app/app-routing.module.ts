
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './modules/shared/page-not-found/page-not-found.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'people', pathMatch: 'full' },
  { path: 'accounting', loadChildren: './modules/accounting/accounting.module#AccountingModule'},
  { path: 'services', loadChildren: './modules/services/services.module#ServicesModule'},
  { path: 'reminders', loadChildren: './modules/reminders/reminders.module#RemindersModule'},
  { path: 'people', loadChildren: './modules/people/people.module#PeopleModule'},
  { path: 'settings', loadChildren: './modules/settings/settings.module#SettingsModule' },
  { path: '**', component: PageNotFoundComponent }
];

export const AppRoutingModule = RouterModule.forRoot(appRoutes, { useHash: true });
