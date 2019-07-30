import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemindersMarriageAnniversaryListComponent } from './reminders-marriage-anniversary-list.component';

describe('RemindersMarriageAnniversaryListComponent', () => {
  let component: RemindersMarriageAnniversaryListComponent;
  let fixture: ComponentFixture<RemindersMarriageAnniversaryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemindersMarriageAnniversaryListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemindersMarriageAnniversaryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
