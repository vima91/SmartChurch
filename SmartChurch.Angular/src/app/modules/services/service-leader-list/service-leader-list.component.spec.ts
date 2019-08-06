import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceLeaderListComponent } from './service-leader-list.component';

describe('ServiceLeaderListComponent', () => {
  let component: ServiceLeaderListComponent;
  let fixture: ComponentFixture<ServiceLeaderListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceLeaderListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceLeaderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
