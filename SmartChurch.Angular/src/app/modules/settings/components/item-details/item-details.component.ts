import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent {

  originalName: string;
  selectedItem: any;
  @Output()
  saved = new EventEmitter();
  @Output()
  cancelled = new EventEmitter();

  @Input()
  set item(item: any) {
    if (item) {
      this.originalName = item.Name;
    }
    this.selectedItem = Object.assign({}, item);
  }

  @Input() hasMoreInfo?: boolean;

  setValue($event: MatSlideToggleChange) {

    this.selectedItem.IsNotLinkableToPersons = $event.checked;
  }
}
