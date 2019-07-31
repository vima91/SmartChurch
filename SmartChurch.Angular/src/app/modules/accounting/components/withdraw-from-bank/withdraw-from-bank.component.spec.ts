import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WithdrawFromBankComponent } from './withdraw-from-bank.component';

describe('WithdrawFromBankComponent', () => {
  let component: WithdrawFromBankComponent;
  let fixture: ComponentFixture<WithdrawFromBankComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WithdrawFromBankComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WithdrawFromBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
