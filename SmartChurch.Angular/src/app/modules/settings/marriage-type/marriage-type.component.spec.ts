import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarriageTypeComponent } from './marriage-type.component';

describe('MarriageTypeComponent', () => {
  let component: MarriageTypeComponent;
  let fixture: ComponentFixture<MarriageTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarriageTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarriageTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
