import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.scss']
})
export class CountryDetailsComponent {

  originalName: string;
  selectedCountry: any;
  @Output()
  saved = new EventEmitter();
  @Output()
  cancelled = new EventEmitter();

  @Input()
  set country(country: any) {
    if (country) {
      this.originalName = country.Name;
    }
    this.selectedCountry = Object.assign({}, country);
  }
}
