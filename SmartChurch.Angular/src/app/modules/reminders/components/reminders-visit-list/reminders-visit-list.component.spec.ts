import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemindersVisitListComponent } from './reminders-visit-list.component';

describe('RemindersVisitListComponent', () => {
  let component: RemindersVisitListComponent;
  let fixture: ComponentFixture<RemindersVisitListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemindersVisitListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemindersVisitListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
