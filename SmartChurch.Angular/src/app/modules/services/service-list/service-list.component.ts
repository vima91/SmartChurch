import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatDialogConfig } from '@angular/material';
import { IService } from '../interfaces/service.interface';
import { HttpService } from 'src/app/API/http.service';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { ServiceEditComponent } from '../components/service-edit/service-edit.component';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.scss']
})
export class ServiceListComponent implements OnInit {
  displayedColumns: string[] = ['Name', 'From', 'To', 'IsWeekly', 'Weekday', 'Comment', 'ViewLeaders', 'ViewSubscription', 'Actions'];
  dataSource: MatTableDataSource<IService>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  services: IService[] = [];
  isLoading = false;

  constructor(private httpService: HttpService,
    private notificationUtil: ToastrService,
    private dialog: MatDialog) {

  }

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

  createService() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    dialogConfig.data = {};
    this.dialog.open(ServiceEditComponent, dialogConfig).afterClosed().subscribe((result: IService) => {
      if (result != undefined) {
        this.createOrUpdateService(result);
      }
    });
  }

  editService(service: IService) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    dialogConfig.data = service;
    this.dialog.open(ServiceEditComponent, dialogConfig).afterClosed().subscribe((result: IService) => {
      if (result != undefined) {
        this.createOrUpdateService(result);
      }
    });
  }


  removeService(service: IService) {
    this.httpService.delete(`${environment.BASE_URL}/api/services/deleteservice/${service.Id}`, service)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${service.Name} is Deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getServices();
      });
  }
  createOrUpdateService(service: IService) {
    if (service.Id != 0) {
      return this.httpService.update(`${environment.BASE_URL}/api/services/updateservice/${service.Id}`, service)
        .subscribe((resp) => {
          this.notificationUtil.success('Success', `${service.Name} is Updated successfully `, {
            positionClass: 'toast-bottom-right'
          });
          this.getServices();
        });
    }
    return this.httpService.create(`${environment.BASE_URL}/api/services/createservice`, service)
      .subscribe((resp) => {
        this.notificationUtil.success('Success', `${service.Name} is Created successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getServices();
      });
  }


}
