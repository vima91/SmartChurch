import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemindersListsComponent } from './reminders-lists.component';

describe('RemindersListsComponent', () => {
  let component: RemindersListsComponent;
  let fixture: ComponentFixture<RemindersListsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemindersListsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemindersListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
