import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss']
})
export class ItemsListComponent {

  _items: any[];

  @Input('items')
  set items(value: any[]) {
    this._items = (value || []).sort((a, b) => {
      return a.Name.toLowerCase().localeCompare(b.Name.toLowerCase());
    });
  }
  @Input()
  readonly = false;
  @Input()
  title = '';
  @Output()
  selected = new EventEmitter();
  @Output()
  deleted = new EventEmitter();
}
