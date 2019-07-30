import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { IPerson } from 'src/app/modules/people/interfaces/person.interface';
import { HttpService } from 'src/app/API/http.service';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reminders-marriage-anniversary-list',
  templateUrl: './reminders-marriage-anniversary-list.component.html',
  styleUrls: ['./reminders-marriage-anniversary-list.component.scss']
})
export class RemindersMarriageAnniversaryListComponent implements OnInit {
  displayedColumns: string[] = ['Name', 'Update'];
  dataSource: MatTableDataSource<IPerson>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  persons: IPerson[] = [];
  isLoading = false;

  constructor(private remindersService: HttpService,
    private notificationUtil: ToastrService) { }

  ngOnInit() {
    this.getReminders();
  }

  /**
   * Set the paginator and sort after the view init since this component will
   * be able to query its view for the initialized paginator and sort.
   */
  ngAfterViewInit() {

    setTimeout(() => {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, 1000);
  }

  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }

  private getReminders() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IPerson>();
    this.remindersService.getAll(`${environment.BASE_URL}/api/reminders/marriageanniversaryreminders`)
      .subscribe((persons) => {
        this.persons = persons;
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(persons);
        this.isLoading = !this.isLoading;
      });
  }
  updateReminder(person: IPerson) {
    this.remindersService.update(`${environment.BASE_URL}/api/reminders/updatepersonmarriageanniversarylastvisit/${person.Id}`, {})
      .subscribe(() => {

        this.notificationUtil.success('Sucess', `${person.Name} is Updated successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getReminders();
      });
  }

}
