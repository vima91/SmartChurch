import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-marital-status',
  templateUrl: './marital-status.component.html',
  styleUrls: ['./marital-status.component.scss']
})
export class MaritalStatusComponent implements OnInit {

  maritalStatus: any[];
  currentMaritalStatus: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {
  }

  ngOnInit() {

    this.getMaritalStatus();
    this.resetCurrentMaritalStatus();
  }

  getMaritalStatus() {
    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/MaritalStatuses`)
      .subscribe(maritalStatus => (this.maritalStatus = maritalStatus));
  }

  resetCurrentMaritalStatus() {

    this.currentMaritalStatus = {Name: ''};
  }

  selectMaritalStatus(maritalStatus) {

    this.currentMaritalStatus = maritalStatus;
  }

  cancel() {

    this.resetCurrentMaritalStatus();
  }

  createMaritalStatus(maritalStatus) {

    const _maritalStatus = maritalStatus;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createMaritalStatus`, maritalStatus).subscribe(() => {

      this.notificationUtil.success('Success', `${_maritalStatus.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getMaritalStatus();
      this.resetCurrentMaritalStatus();
    });
  }

  updateMaritalStatus(maritalStatus) {

    const _maritalStatus = maritalStatus;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updateMaritalStatus/${maritalStatus.Id}`, maritalStatus)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${_maritalStatus.Name} is Updated successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getMaritalStatus();
        this.resetCurrentMaritalStatus();
      });
  }

  deleteMaritalStatus(maritalStatus) {

    const _maritalStatus = maritalStatus;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deleteMaritalStatus/${maritalStatus.Id}`, maritalStatus)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${_maritalStatus.Name} is deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getMaritalStatus();
        this.resetCurrentMaritalStatus();
      });
  }

  savedMaritalStatus(maritalStatus) {

    if (!maritalStatus.Id) {

      return this.createMaritalStatus(maritalStatus);
    }
    return this.updateMaritalStatus(maritalStatus);
  }

}
