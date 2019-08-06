import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceSubscriptionEditComponent } from './service-subscription-edit.component';

describe('ServiceSubscriptionEditComponent', () => {
  let component: ServiceSubscriptionEditComponent;
  let fixture: ComponentFixture<ServiceSubscriptionEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceSubscriptionEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceSubscriptionEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
