import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-marriage-type',
  templateUrl: './marriage-type.component.html',
  styleUrls: ['./marriage-type.component.scss']
})
export class MarriageTypeComponent implements OnInit {

  marriageTypes: any[];
  currentMarriageType: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {
  }

  ngOnInit() {

    this.getMarriageType();
    this.resetCurrentMarriageType();
  }

  getMarriageType() {
    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/marriagetypes`)
      .subscribe(marriageTypes => (this.marriageTypes = marriageTypes));
  }

  resetCurrentMarriageType() {

    this.currentMarriageType = {Name: ''};
  }

  selectMarriageType(marriageType) {

    this.currentMarriageType = marriageType;
  }

  cancel() {

    this.resetCurrentMarriageType();
  }

  createMarriageType(marriageType) {

    const _marriageType = marriageType;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createmarriagetype`, marriageType).subscribe(() => {

      this.notificationUtil.success('Success', `${_marriageType.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getMarriageType();
      this.resetCurrentMarriageType();
    });
  }

  updateMarriageType(marriageType) {

    const _marriageType = marriageType;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updatemarriagetype/${marriageType.Id}`, marriageType)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${_marriageType.Name} is Updated successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getMarriageType();
        this.resetCurrentMarriageType();
      });
  }

  deleteMarriageType(marriageType) {

    const _marriageType = marriageType;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deletemarriagetype/${marriageType.Id}`, marriageType)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${_marriageType.Name} is deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getMarriageType();
        this.resetCurrentMarriageType();
      });
  }

  savedMarriageType(marriageType) {

    if (!marriageType.Id) {

      return this.createMarriageType(marriageType);
    }
    return this.updateMarriageType(marriageType);
  }

}
