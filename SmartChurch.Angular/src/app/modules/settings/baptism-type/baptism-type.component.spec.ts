import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BaptismTypeComponent } from './baptism-type.component';

describe('BaptismTypeComponent', () => {
  let component: BaptismTypeComponent;
  let fixture: ComponentFixture<BaptismTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BaptismTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BaptismTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
