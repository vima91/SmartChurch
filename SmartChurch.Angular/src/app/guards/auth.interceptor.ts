
import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from '@angular/common/http';
import { Observable } from 'rxjs';

export class AuthInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add authorization header with jwt token if available
    const user = JSON.parse(localStorage.getItem('user'));
    if (user && user.Token) {
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json'
        }
      });
    }
    return next.handle(req);
  }

}
