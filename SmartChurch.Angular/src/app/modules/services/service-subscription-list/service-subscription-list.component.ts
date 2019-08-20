import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatDialogConfig } from '@angular/material';
import { IServiceSubscription } from '../interfaces/service-subscription.interface';
import { HttpService } from 'src/app/API/http.service';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { ServiceSubscriptionEditComponent } from '../components/service-subscription-edit/service-subscription-edit.component';


@Component({
  selector: 'app-service-subscription-list',
  templateUrl: './service-subscription-list.component.html',
  styleUrls: ['./service-subscription-list.component.scss']
})
export class ServiceSubscriptionListComponent implements OnInit {
  displayedColumns: string[] = ['PersonName', 'edit', 'delete'];
  serviceName: string;
  dataSource: MatTableDataSource<IServiceSubscription>;
  id: number;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  subscriptionsList: IServiceSubscription[] = [];
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
    this.dataSource = new MatTableDataSource<IServiceSubscription>();
    this.httpService.getAll(`${environment.BASE_URL}/api/services/ServiceSubscriptionsByService/${this.id}`)
      .subscribe(serviceSubscriptions => {
        this.subscriptionsList = serviceSubscriptions;
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(serviceSubscriptions);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort; 
        this.isLoading = !this.isLoading;
      });
  }


  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }

  createSubscription() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    dialogConfig.data = {};
    this.dialog.open(ServiceSubscriptionEditComponent, dialogConfig).afterClosed().subscribe((result: IServiceSubscription) => {
      if (result != undefined) {
        result.ServiceId = this.id;
        this.createOrUpdateSubscription(result);
      }
    });
  }

  editSubscription(serviceSubscription: IServiceSubscription) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    dialogConfig.data = serviceSubscription;
    this.dialog.open(ServiceSubscriptionEditComponent, dialogConfig).afterClosed().subscribe((result: IServiceSubscription) => {
      if (result != undefined) {
        result.ServiceId = this.id;
        this.createOrUpdateSubscription(result);
      }
    });
  }


  removeSubscription(serviceSubscription: IServiceSubscription) {
    this.httpService.delete(`${environment.BASE_URL}/api/services/DeleteServiceSubscription/${serviceSubscription.Id}`, serviceSubscription)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${serviceSubscription.PersonName} is Deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getServices();
      });
  }

  createOrUpdateSubscription(serviceSubscription: IServiceSubscription) {
    if (serviceSubscription.Id != 0) {
      return this.httpService.update(`${environment.BASE_URL}/api/services/UpdateServiceSubscription/${serviceSubscription.Id}`, serviceSubscription)
        .subscribe((resp) => {
          this.notificationUtil.success('Success', `Updated successfully `, {
            positionClass: 'toast-bottom-right'
          });
          this.getServices();
        });
    }
    return this.httpService.create(`${environment.BASE_URL}/api/services/CreateServiceSubscription`, serviceSubscription)
      .subscribe((resp) => {
        this.notificationUtil.success('Success', `Created successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getServices();
      });
  }


}
