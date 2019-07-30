import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-service-type',
  templateUrl: './service-type.component.html',
  styleUrls: ['./service-type.component.scss']
})
export class ServiceTypeComponent implements OnInit {

  serviceTypes: any[];
  currentServiceType: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {}

  ngOnInit() {

    this.getServiceTypes();
    this.resetCurrentServiceType();
  }

  getServiceTypes() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/ServiceTypes`)
      .subscribe(serviceTypes => (this.serviceTypes = serviceTypes));
  }

  resetCurrentServiceType() {

    this.currentServiceType = { Name: ''};
  }

  selectServiceType(serviceType) {

    this.currentServiceType = serviceType;
  }

  cancel() {

    this.resetCurrentServiceType();
  }

  createServiceType(serviceType) {

    const _serviceType = serviceType;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createServiceType`, serviceType).subscribe(() => {

      this.notificationUtil.success('Success', `${_serviceType.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getServiceTypes();
      this.resetCurrentServiceType();
    });
  }

  updateServiceType(serviceType) {

    const _serviceType = serviceType;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updateServiceType/${serviceType.Id}`, serviceType).subscribe(() => {

      this.notificationUtil.success('Success', `${_serviceType.Name} is Updated successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getServiceTypes();
      this.resetCurrentServiceType();
    });
  }

  deleteServiceType(serviceType) {

    const _serviceType = serviceType;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deleteServiceType/${serviceType.Id}`, serviceType).subscribe(() => {

      this.notificationUtil.success('Success', `${_serviceType.Name} is deleted successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getServiceTypes();
      this.resetCurrentServiceType();
    });
  }

  savedServiceType(serviceType) {

    if (!serviceType.Id) {

      return this.createServiceType(serviceType);
    }
    return this.updateServiceType(serviceType);
  }


}
