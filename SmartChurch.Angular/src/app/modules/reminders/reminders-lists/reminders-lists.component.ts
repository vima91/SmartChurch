import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../API/http.service';
import { environment } from '../../../../environments/environment';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-reminders-lists',
  templateUrl: './reminders-lists.component.html',
  styleUrls: ['./reminders-lists.component.scss']
})
export class RemindersListsComponent implements OnInit {
  visitCounter = 0;
  birthdayCounter = 0;
  marriageAnniversaryCounter = 0;
  visitRemindersEvent:any;
  birthdayRemindersEvent:any;
  marriageAnniversaryRemindersEvent:any;

  constructor(
    private remindersService: HttpService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {

    this.getReminders();
  }

  getReminders() {
    this.remindersService.getAll(`${environment.BASE_URL}/api/reminders/visitreminders`)
      .subscribe((visitReminders) => (this.visitCounter = visitReminders.length));
    this.remindersService.getAll(`${environment.BASE_URL}/api/reminders/birthdayreminders`)
      .subscribe((birthdayReminders) => (this.birthdayCounter = birthdayReminders.length));
    this.remindersService.getAll(`${environment.BASE_URL}/api/reminders/marriageanniversaryreminders`)
      .subscribe((marriageAnniversaryReminders) => (this.marriageAnniversaryCounter = marriageAnniversaryReminders.length));
  }

  onCountoEnd(): void {
  }

  openBirthdayReminders() {
    this.router.navigate(['reminders/birthday-reminders']);
  }

  openVisitReminders() {
    this.router.navigate(['reminders/visit-reminders']);
  }

  openMarriageAnniversaryReminders() {
    this.router.navigate(['reminders/marriage-anniversary-reminders']);
  }

}
