import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from './header/header.component';
import { HeaderBrandingComponent } from './header-branding/header-branding.component';
import { HeaderLinksComponent } from './header-links/header-links.component';
import { HeaderSessionControlComponent } from './header-session-control/header-session-control.component';
import { MaterialModule } from '../material.module';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule
  ],
  declarations: [HeaderComponent, HeaderBrandingComponent, HeaderLinksComponent, HeaderSessionControlComponent],
  exports: [HeaderComponent]
})
export class LayoutsModule { }
