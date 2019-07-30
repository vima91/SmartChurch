import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {

  countries: any[];
  currentCountry: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {}

  ngOnInit() {

    this.getCounties();
    this.resetCurrentCountry();
  }

  getCounties() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/countries`)
      .subscribe(countries => (this.countries = countries));
  }

  resetCurrentCountry() {

    this.currentCountry = { Name: ''};
  }

  selectCountry(country) {

    this.currentCountry = country;
  }

  cancel() {

    this.resetCurrentCountry();
  }

  createCountry(country) {

    const _country = country;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createcountry`, country).subscribe(() => {

      this.notificationUtil.success('Success', `${_country.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getCounties();
      this.resetCurrentCountry();
    });
  }

  updateCountry(country) {

    const _country = country;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updatecountry/${country.Id}`, country).subscribe(() => {

      this.notificationUtil.success('Success', `${_country.Name} is Updated successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getCounties();
      this.resetCurrentCountry();
    });
  }

  deleteCountry(country) {

    const _country = country;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deletecountry/${country.Id}`, country).subscribe(() => {

      this.notificationUtil.success('Success', `${_country.Name} is deleted successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getCounties();
      this.resetCurrentCountry();
    });
  }

  savedCountry(country) {

    if (!country.Id) {

      return this.createCountry(country);
    }
    return this.updateCountry(country);
  }

}
