import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../modules/authentication/services/authentication.service';

@Component({
  selector: 'app-header-session-control',
  templateUrl: './header-session-control.component.html',
  styleUrls: ['./header-session-control.component.scss']
})
export class HeaderSessionControlComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  logout() {
    this.authenticationService.logout();
  }
}
