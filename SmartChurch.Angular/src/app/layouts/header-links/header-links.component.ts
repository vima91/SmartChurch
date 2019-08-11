import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-links',
  templateUrl: './header-links.component.html',
  styleUrls: ['./header-links.component.scss']
})
export class HeaderLinksComponent implements OnInit {

  links = [
    {path: '/attendances', label: 'Attendances'},
    {path: '/accounting', label: 'Accounting'},
    {path: '/services', label: 'Services'},
    {path: '/reminders', label: 'Reminders'},
    {path: '/people', label: 'People'},
    {path: '/settings', label: 'Settings'}
  ];

  constructor() {
  }

  ngOnInit() {
  }

}
