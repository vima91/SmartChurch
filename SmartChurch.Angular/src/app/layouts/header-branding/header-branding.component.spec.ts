import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderBrandingComponent } from './header-branding.component';

describe('HeaderBrandingComponent', () => {
  let component: HeaderBrandingComponent;
  let fixture: ComponentFixture<HeaderBrandingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderBrandingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderBrandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
