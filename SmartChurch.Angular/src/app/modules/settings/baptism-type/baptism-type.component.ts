import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-baptism-type',
  templateUrl: './baptism-type.component.html',
  styleUrls: ['./baptism-type.component.scss']
})
export class BaptismTypeComponent implements OnInit {

  baptismTypes: any[];
  currentBaptismType: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {}

  ngOnInit() {

    this.getBaptismTypes();
    this.resetCurrentBaptismType();
  }

  getBaptismTypes() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/BaptismTypes`)
      .subscribe(baptismTypes => (this.baptismTypes = baptismTypes));
  }

  resetCurrentBaptismType() {

    this.currentBaptismType = { Name: ''};
  }

  selectBaptismType(baptismType) {

    this.currentBaptismType = baptismType;
  }

  cancel() {

    this.resetCurrentBaptismType();
  }

  createBaptismType(baptismType) {

    const _baptismType = baptismType;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createBaptismType`, baptismType).subscribe(() => {

      this.notificationUtil.success('Success', `${_baptismType.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getBaptismTypes();
      this.resetCurrentBaptismType();
    });
  }

  updateBaptismType(baptismType) {

    const _baptismType = baptismType;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updateBaptismType/${baptismType.Id}`, baptismType).subscribe(() => {

      this.notificationUtil.success('Success', `${_baptismType.Name} is Updated successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getBaptismTypes();
      this.resetCurrentBaptismType();
    });
  }

  deleteBaptismType(baptismType) {

    const _baptismType = baptismType;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deleteBaptismType/${baptismType.Id}`, baptismType).subscribe(() => {

      this.notificationUtil.success('Success', `${_baptismType.Name} is deleted successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getBaptismTypes();
      this.resetCurrentBaptismType();
    });
  }

  savedBaptismType(baptismType) {

    if (!baptismType.Id) {

      return this.createBaptismType(baptismType);
    }
    return this.updateBaptismType(baptismType);
  }

}
