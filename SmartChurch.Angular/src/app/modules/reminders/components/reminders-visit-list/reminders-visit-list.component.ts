import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { IPerson } from 'src/app/modules/people/interfaces/person.interface';
import { HttpService } from 'src/app/API/http.service';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reminders-visit-list',
  templateUrl: './reminders-visit-list.component.html',
  styleUrls: ['./reminders-visit-list.component.scss']
})
export class RemindersVisitListComponent implements OnInit {
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

  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }

  private getReminders() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IPerson>();
    this.remindersService.getAll(`${environment.BASE_URL}/api/reminders/visitreminders`)
      .subscribe((persons) => {
        this.persons = persons;
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(persons);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;  
        this.isLoading = !this.isLoading;
      });
  }
  updateReminder(person: IPerson) {
    this.remindersService.update(`${environment.BASE_URL}/api/reminders/updatepersonlastvisit/${person.Id}`, {})
      .subscribe(() => {

        this.notificationUtil.success('Sucess', `${person.Name} is Updated successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getReminders();
      });
  }

}
