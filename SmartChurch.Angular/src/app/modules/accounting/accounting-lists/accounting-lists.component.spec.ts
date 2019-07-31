import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountingListsComponent } from './accounting-lists.component';

describe('AccountingListsComponent', () => {
  let component: AccountingListsComponent;
  let fixture: ComponentFixture<AccountingListsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountingListsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountingListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
