import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

    this.settingsService.getItemById(`${environment.BASE_URL}/api/settings/AppSettings`)
      .subscribe(appSettings => {
        this.appSettings = <IAppSettings>appSettings;
        this.appSettingsForm.patchValue(this.appSettings);
      });
  }

  ngOnInit() {
    this.appSettingsForm = this.fb.group({
      AppName: ['', Validators.required],
      AppLogo: [''],
      Id: [''],
      CountryId: [''],
      City: [''],
      StartOfSchoolYear: [''],
      ChurchBalanceReminder: [''],
      BankBalanceReminder: [''],
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.appSettingsForm.controls;
  }

  updatePersonalInformation() {
    if (this.appSettingsForm.valid) {
      return this.settingsService.update(`${environment.BASE_URL}/api/settings/UpdateAppSettings`, this.appSettingsForm.value)
        .subscribe(result => {
          this._toaster.success('Success', `Updated successfully `, {
            positionClass: 'toast-bottom-right'
          });
        }, error => {
          this._toaster.error(error.message, `Error`, {
            positionClass: 'toast-bottom-right'
          });
        });
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
        this.appSettingsForm.patchValue({
          AppLogo: this.newAvatarImagePath
        });

      };
    }
  }
}
