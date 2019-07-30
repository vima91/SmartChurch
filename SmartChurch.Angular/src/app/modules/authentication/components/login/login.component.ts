import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EMAIL_PATTERN } from '../../../../validation/patterns';
import { Subject } from 'rxjs';
import { first, takeUntil } from 'rxjs/operators';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  formGroup: FormGroup;
  returnUrl: string;
  hide = true;
  unsubscribe$ = new Subject();

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) {
  }

  ngOnInit() {

    this.formGroup = this.formBuilder.group({
      Username: ['', Validators.compose([Validators.required, Validators.minLength(6), Validators.pattern(EMAIL_PATTERN)])],
      Password: ['', Validators.compose([Validators.required])]
    });

    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  getFormValue(field: string): string {
    return this.formGroup.controls[field].value;
  }


  // login
  login() {

    this.authenticationService.login({
      Username: this.getFormValue('Username'),
      Password: this.getFormValue('Password')
    });
    this.router.navigate(['']);

    this.authenticationService
      .login({
        Username: this.getFormValue('Username'),
        Password: this.getFormValue('Password')
      })
      .pipe(
        first(),
        takeUntil(this.unsubscribe$)
      )
      .subscribe(() => {
        this.router.navigate(['']);
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }


  lazyLogin() {
    this.authenticationService
      .login({
        Username: 'evram.ehab@gmail.com',
        Password: 'Pa$$w0rd'
      })
      .pipe(
        first(),
        takeUntil(this.unsubscribe$)
      )
      .subscribe(() => {
        this.router.navigate(['']);
      });
  }
}
