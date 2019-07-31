import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepoisteToBankComponent } from './depoiste-to-bank.component';

describe('DepoisteToBankComponent', () => {
  let component: DepoisteToBankComponent;
  let fixture: ComponentFixture<DepoisteToBankComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepoisteToBankComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepoisteToBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
