import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendancesListComponent } from './attendances-list.component';

describe('AttendancesListComponent', () => {
  let component: AttendancesListComponent;
  let fixture: ComponentFixture<AttendancesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttendancesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendancesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
