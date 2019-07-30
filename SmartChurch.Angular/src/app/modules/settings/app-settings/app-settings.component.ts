import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from '../../../API/http.service';
import { environment } from '../../../../environments/environment';
import { IAppSettings } from '../interfaces/app-settings.interface';

@Component({
  selector: 'app-app-settings',
  templateUrl: './app-settings.component.html',
  styleUrls: ['./app-settings.component.scss']
})
export class AppSettingsComponent implements OnInit {

  newAvatarImagePath = 'https://image.shutterstock.com/image-photo/close-photo-cheerful-excited-glad-260nw-789414166.jpg';
  appSettings: IAppSettings;
  appSettingsForm: FormGroup;
  newImageServerPath = null;

  constructor(private fb: FormBuilder,
              private settingsService: HttpService,
              private _toaster: ToastrService) {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/AppSettings`)
      .subscribe(appSettings => {
        this.appSettings = appSettings[0];
        console.log(this.appSettings);
        this.appSettingsForm.patchValue(this.appSettings);
      });
    /*this.sharedService.changeEmitted$.subscribe(newPath => {
      this.newAvatarImagePath = `${environment.apiEndpoint}${newPath}`;
    });*/
  }

  ngOnInit() {
    this.appSettingsForm = this.fb.group({
      AppName: [''],
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.appSettingsForm.controls;
  }

  updatePersonalInformation() {
    const payload = {};

    if (Object.keys(payload).length) {
      /*this._http
        .postData(`${environment.apiEndpoint}/v2/users/editUser`, {}, payload)
        .subscribe(res => this._toaster.success('Data Updated', 'Success'));*/
      this._toaster.warning('Please update info first', 'Warning');
    }
  }

  uploadProfileImage(event) {
    if (
      event.target['files'] &&
      event.target['files'][0] &&
      event !== undefined
    ) {
      const file = event.target['files'][0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = onload => {
        // called once readAsDataURL is completed
        this.newAvatarImagePath = onload.target['result'];
        console.log('this.newAvatarImagePath', this.newAvatarImagePath);

      };
    }
  }
}
