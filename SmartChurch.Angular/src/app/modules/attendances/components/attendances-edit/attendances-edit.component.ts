import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { IServiceLeader } from 'src/app/modules/services/interfaces/service-leader.interface';
import { HttpService } from 'src/app/API/http.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { IAttendance } from '../../interfaces/attendance.interface';
import { IExpense } from 'src/app/modules/accounting/interfaces/expense.interface';

@Component({
  selector: 'app-attendances-edit',
  templateUrl: './attendances-edit.component.html',
  styleUrls: ['./attendances-edit.component.scss']
})
export class AttendancesEditComponent implements OnInit {
  displayedColumns: string[] = ['PersonName', 'DateOfEvent', 'Comment', 'Update'];
  serviceName: string;
  id: number;
  dataSource: MatTableDataSource<IServiceLeader>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  attendancesList: IServiceLeader[] = [];
  isLoading = false;

  constructor(private httpService: HttpService,
    private notificationUtil: ToastrService,
    private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params && params.id) {
        this.id = +params.id;
        this.getAttendances();
        this.serviceName = params.name;
      }
    });

  }

  getAttendances() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IServiceLeader>();
    this.httpService.getAll(`${environment.BASE_URL}/api/attendance/AttendancesByService/${this.id}`)
      .subscribe(attendances => {
        this.attendancesList = attendances || [];
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(attendances);
        this.isLoading = !this.isLoading;
      });
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

  editAttendance(attendance: IAttendance) {
    attendance.IsAttended = !attendance.IsAttended;
    return this.httpService.update(`${environment.BASE_URL}/api/attendance/UpdateAttendance/${attendance.Id}`, attendance)
      .subscribe(result => {
        this.notificationUtil.success('Success', `Updated successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getAttendances();
      }, error => {
        attendance.IsAttended = !attendance.IsAttended;
      });
  }



}
