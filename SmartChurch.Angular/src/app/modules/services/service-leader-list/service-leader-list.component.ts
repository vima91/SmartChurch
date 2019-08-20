import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatDialogConfig } from '@angular/material';
import { IServiceLeader } from '../interfaces/service-leader.interface';
import { HttpService } from 'src/app/API/http.service';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { ServiceLeaderEditComponent } from '../components/service-leader-edit/service-leader-edit.component';


@Component({
  selector: 'app-service-leader-list',
  templateUrl: './service-leader-list.component.html',
  styleUrls: ['./service-leader-list.component.scss']
})
export class ServiceLeaderListComponent implements OnInit {
  displayedColumns: string[] = ['PersonName', 'edit', 'delete'];
  serviceName: string;
  dataSource: MatTableDataSource<IServiceLeader>;
  id: number;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  leadersList: IServiceLeader[] = [];
  isLoading = false;

  constructor(private httpService: HttpService,
    private notificationUtil: ToastrService,
    private dialog: MatDialog,
    private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params && params.id) {
        this.id = +params.id;
        this.getServices();
        this.serviceName = params.name;
      }
    });

  }

  getServices() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IServiceLeader>();
    this.httpService.getAll(`${environment.BASE_URL}/api/services/ServiceLeadersByService/${this.id}`)
      .subscribe(serviceLeaders => {
        this.leadersList = serviceLeaders;
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(serviceLeaders);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort; 
        this.isLoading = !this.isLoading;
      });
  }

  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }

  createLeader() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    dialogConfig.data = {};
    this.dialog.open(ServiceLeaderEditComponent, dialogConfig).afterClosed().subscribe((result: IServiceLeader) => {
      if (result != undefined) {
        result.ServiceId = this.id;
        this.createOrUpdateLeader(result);
      }
    });
  }

  editLeader(serviceLeader: IServiceLeader) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    dialogConfig.data = serviceLeader;
    this.dialog.open(ServiceLeaderEditComponent, dialogConfig).afterClosed().subscribe((result: IServiceLeader) => {
      if (result != undefined) {
        result.ServiceId = this.id;
        this.createOrUpdateLeader(result);
      }
    });
  }


  removeLeader(serviceLeader: IServiceLeader) {
    this.httpService.delete(`${environment.BASE_URL}/api/services/DeleteServiceLeader/${serviceLeader.Id}`, serviceLeader)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${serviceLeader.PersonName} is Deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getServices();
      });
  }

  createOrUpdateLeader(serviceLeader: IServiceLeader) {
    if (serviceLeader.Id != 0) {
      return this.httpService.update(`${environment.BASE_URL}/api/services/UpdateServiceLeader/${serviceLeader.Id}`, serviceLeader)
        .subscribe((resp) => {
          this.notificationUtil.success('Success', `Updated successfully `, {
            positionClass: 'toast-bottom-right'
          });
          this.getServices();
        });
    }
    return this.httpService.create(`${environment.BASE_URL}/api/services/CreateServiceLeader`, serviceLeader)
      .subscribe((resp) => {
        this.notificationUtil.success('Success', `Created successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getServices();
      });
  }


}
