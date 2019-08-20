import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { IService } from '../../services/interfaces/service.interface';
import { HttpService } from 'src/app/API/http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-attendances-list',
  templateUrl: './attendances-list.component.html',
  styleUrls: ['./attendances-list.component.scss']
})
export class AttendancesListComponent implements OnInit {
  displayedColumns: string[] = ['Name', 'From', 'To', 'IsWeekly', 'DayOfWeek', 'Comment', 'Action'];
  dataSource: MatTableDataSource<IService>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  services: IService[] = [];
  isLoading = false;

  constructor(private httpService: HttpService) {}

  ngOnInit(): void {

    this.getServices();
  }

  getServices() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IService>();
    this.httpService.getAll(`${environment.BASE_URL}/api/services/services`)
      .subscribe(services => {
        this.services = services || [];
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(this.services);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.isLoading = !this.isLoading;
      });
  }

  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }
}
