import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemindersViewDetailsComponent } from './reminders-view-details.component';

describe('RemindersViewDetailsComponent', () => {
  let component: RemindersViewDetailsComponent;
  let fixture: ComponentFixture<RemindersViewDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemindersViewDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemindersViewDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
