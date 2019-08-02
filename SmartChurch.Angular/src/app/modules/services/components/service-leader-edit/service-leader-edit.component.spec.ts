import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceLeaderEditComponent } from './service-leader-edit.component';

describe('ServiceLeaderEditComponent', () => {
  let component: ServiceLeaderEditComponent;
  let fixture: ComponentFixture<ServiceLeaderEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceLeaderEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceLeaderEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
