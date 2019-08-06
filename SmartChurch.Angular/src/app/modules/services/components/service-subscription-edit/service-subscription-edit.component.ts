import { Component, OnInit, Inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Validators, FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { HttpService } from 'src/app/API/http.service';

@Component({
  selector: 'app-service-subscription-edit',
  templateUrl: './service-subscription-edit.component.html',
  styleUrls: ['./service-subscription-edit.component.scss']
})
export class ServiceSubscriptionEditComponent implements OnInit {
  form: FormGroup;
  subscriptions: any[];

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<ServiceSubscriptionEditComponent>,
    private settingsService: HttpService,
    @Inject(MAT_DIALOG_DATA) data) {
    this.form = this.fb.group({
      Id: new FormControl(data.Id || 0),
      ServiceId: new FormControl(data.ServiceId || 0),
      PersonId: new FormControl(data.PersonId, [Validators.required])
    });
  }

  ngOnInit() {
    this.getPerson();
  }

  getPerson() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/person/persons`)
      .subscribe(subscriptions => {
        this.subscriptions = subscriptions.filter(x => x.IsServant != true);
      });

  }

  hasError(controlName: string, errorName: string) {
    return this.form.controls[controlName].hasError(errorName);
  }

  save() {
    if (this.form.valid)
      this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }

}

