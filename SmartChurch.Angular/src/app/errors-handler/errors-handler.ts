import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable()
export class ErrorsHandler implements ErrorHandler {
  // Because the ErrorHandler is created before the providers,
  // we’ll have to use the Injector to get them.
  constructor(private injector: Injector) {}

  handleError(error: Error | HttpErrorResponse) {
    enum ERROR_TYPE {
      BAD_REQUEST = 400,
      UNAUTHORIZED = 401,
      FORBIDDEN = 403,
      NOT_FOUND = 404,
      INTERNAL_SERVER_ERROR = 500
    }
    const toaster = this.injector.get(ToastrService);
    const router = this.injector.get(Router);
    if (error instanceof HttpErrorResponse) {
      // Server or connection error happened
      if (!navigator.onLine) {
        // Handle offline error
        toaster.error('No Internet Connection', 'Error');
      } else {
        const errorMsg = ', ' + error['error']['message'];
        // Handle Http Error (error.status === 403, 404...)
        switch (error.status) {
          case ERROR_TYPE.BAD_REQUEST:
            toaster.error(`Bad Request ${errorMsg}`, 'Error');
            break;
          case ERROR_TYPE.UNAUTHORIZED:
            router.navigate(['/login']);
            toaster.error(`Unauthorized ${errorMsg}`, 'Error');
            break;
          case ERROR_TYPE.NOT_FOUND:
            toaster.error(`Not Found ${errorMsg}`, 'Error');
            break;
          case ERROR_TYPE.FORBIDDEN:
            toaster.error(`Forbidden ${errorMsg}`, 'Error');
            break;
          case ERROR_TYPE.INTERNAL_SERVER_ERROR:
            toaster.error(`Internal Server Error ${errorMsg}`, 'Error');
            break;
        }
      }
    } else {
      // Handle Client Error (Angular Error, ReferenceError...)
      router.navigate(['/error'], { queryParams: { error: error } });
    }
    // Log the error anyway
    console.error('ChurchOrganizer Error happens: ', error);
  }
}
