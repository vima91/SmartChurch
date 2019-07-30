import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemindersBirthdayListComponent } from './reminders-birthday-list.component';

describe('RemindersBirthdayListComponent', () => {
  let component: RemindersBirthdayListComponent;
  let fixture: ComponentFixture<RemindersBirthdayListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemindersBirthdayListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemindersBirthdayListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
