import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-religious-type',
  templateUrl: './religious-type.component.html',
  styleUrls: ['./religious-type.component.scss']
})
export class ReligiousTypeComponent implements OnInit {

  religiousTypes: any[];
  currentReligiousType: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {
  }

  ngOnInit() {

    this.getReligiousType();
    this.resetCurrentReligiousType();
  }

  getReligiousType() {
    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/religiousbackgrounds`)
      .subscribe(religiousTypes => (this.religiousTypes = religiousTypes));
  }

  resetCurrentReligiousType() {

    this.currentReligiousType = {Name: ''};
  }

  selectReligiousType(religiousType) {

    this.currentReligiousType = religiousType;
  }

  cancel() {

    this.resetCurrentReligiousType();
  }

  createReligiousType(religiousType) {

    const _religiousType = religiousType;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createreligiousbackground`, religiousType).subscribe(() => {

      this.notificationUtil.success('Success', `${_religiousType.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getReligiousType();
      this.resetCurrentReligiousType();
    });
  }

  updateReligiousType(religiousType) {

    const _religiousType = religiousType;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updatereligiousbackground/${religiousType.Id}`, religiousType)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${_religiousType.Name} is Updated successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getReligiousType();
        this.resetCurrentReligiousType();
      });
  }

  deleteReligiousType(religiousType) {

    const _religiousType = religiousType;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deletereligiousbackground/${religiousType.Id}`, religiousType)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${_religiousType.Name} is deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getReligiousType();
        this.resetCurrentReligiousType();
      });
  }

  savedReligiousType(religiousType) {

    if (!religiousType.Id) {

      return this.createReligiousType(religiousType);
    }
    return this.updateReligiousType(religiousType);
  }

}
