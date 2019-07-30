import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReligiousTypeComponent } from './religious-type.component';

describe('ReligiousTypeComponent', () => {
  let component: ReligiousTypeComponent;
  let fixture: ComponentFixture<ReligiousTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReligiousTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReligiousTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
