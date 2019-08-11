import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendancesEditComponent } from './attendances-edit.component';

describe('AttendancesEditComponent', () => {
  let component: AttendancesEditComponent;
  let fixture: ComponentFixture<AttendancesEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttendancesEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendancesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
