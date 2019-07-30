import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

import { SharedModule } from './modules/shared/shared.module';
import { AuthenticationModule } from './modules/authentication/authentication.module';
import { CountoModule } from 'angular2-counto';

import { ErrorComponent } from './errors-handler/error/error.component';
import { ErrorsHandler } from './errors-handler/errors-handler';
import { AuthInterceptor } from './guards/auth.interceptor';
import { AuthGuard } from './guards/auth.guard';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { LayoutsModule } from './layouts/layouts.module';
import { AppComponent } from './app.component';
import { HttpService } from './API/http.service';

@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    CommonModule,
    LayoutsModule,
    CountoModule,
    SharedModule,
    AppRoutingModule,
    AuthenticationModule
  ],
  providers: [
    {
      provide: ErrorHandler,
      useClass: ErrorsHandler
    }, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    AuthGuard,
    HttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
