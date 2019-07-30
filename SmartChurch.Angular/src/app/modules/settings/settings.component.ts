import { Component } from '@angular/core';


@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent {


  links = [
    { path: '/settings/country', icon: 'location_city', label: 'Country' },
    { path: '/settings/baptism-type', icon: 'merge_type', label: 'Baptism Type' },
    { path: '/settings/expense-type', icon: 'merge_type', label: 'Expense Type' },
    { path: '/settings/marriage-type', icon: 'person', label: 'Marriage Type' },
    { path: '/settings/religious-type', icon: 'list', label: 'Religious Type' },
    { path: '/settings/service-type', icon: 'adjust', label: 'Service Type' },
    { path: '/settings/marital-status', icon: 'merge_type', label: 'Marital Status' },
    { path: '/settings/grade', icon: 'grade', label: 'Grade' },
    { path: '/settings/app-settings', icon: 'settings', label: 'App Settings' }
  ];
}
