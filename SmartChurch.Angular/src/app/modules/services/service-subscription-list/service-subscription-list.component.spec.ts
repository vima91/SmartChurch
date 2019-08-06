import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceSubscriptionListComponent } from './service-subscription-list.component';

describe('ServiceSubscriptionListComponent', () => {
  let component: ServiceSubscriptionListComponent;
  let fixture: ComponentFixture<ServiceSubscriptionListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceSubscriptionListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceSubscriptionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
