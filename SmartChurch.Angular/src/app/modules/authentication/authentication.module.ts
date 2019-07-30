import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material.module';
import { LoginComponent } from './components/login/login.component';
import { AuthenticationService } from './services/authentication.service';

import { routing } from './authentication.routing';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    routing,
  ],
  declarations: [LoginComponent],
  providers: [AuthenticationService]
})
export class AuthenticationModule { }
