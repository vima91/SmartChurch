import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {



  constructor(private http: HttpClient, private notificationUtil: ToastrService, private router: Router) {}

  login(payload: { Username: string; Password: string }) {


    return this.http
      .post<any>(`${environment.BASE_URL}/users/authenticate`, payload)
      .pipe(map(user => {
        // login successful if there's a token in the response
        if (user && user.Token) {
          // store user token in local storage to keep user logged in between page refreshes
          localStorage.setItem('user', JSON.stringify(user));
          this.notificationUtil.success('Welcome Again', `Hello, ${user.Username}`, {
            positionClass: 'toast-bottom-right'
          });
        }
        return user;
      }));
  }

  logout() {
    localStorage.removeItem('user');
    this.router.navigate(['/auth/login']);

  }
}
