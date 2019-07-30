import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderSessionControlComponent } from './header-session-control.component';

describe('HeaderSessionControlComponent', () => {
  let component: HeaderSessionControlComponent;
  let fixture: ComponentFixture<HeaderSessionControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderSessionControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderSessionControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
