import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent {

  _countries: any[];

  @Input('countries')
  set countries(value: any[]) {
    this._countries = (value || []).sort((a, b) => {
      return a.Name.toLowerCase().localeCompare(b.Name.toLowerCase());
    });
  }
  @Input()
  readonly = false;
  @Output()
  selected = new EventEmitter();
  @Output()
  deleted = new EventEmitter();

}
