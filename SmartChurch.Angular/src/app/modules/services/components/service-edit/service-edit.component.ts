import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { HttpService } from 'src/app/API/http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-service-edit',
  templateUrl: './service-edit.component.html',
  styleUrls: ['./service-edit.component.scss']
})
export class ServiceEditComponent implements OnInit {
  form: FormGroup;
  serviceTypes: any[];

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<ServiceEditComponent>,
    private settingsService: HttpService,
    @Inject(MAT_DIALOG_DATA) data) {
    this.form = this.fb.group({
      Id: new FormControl(data.Id || 0),
      Name: new FormControl(data.Name, [Validators.required]),
      ServiceTypeId: new FormControl(data.ServiceTypeId, [Validators.required]),
      From: new FormControl(data.From || new Date(), [Validators.required]),
      To: new FormControl(data.To || new Date(), [Validators.required]),
      Weekday: new FormControl(data.Weekday, [Validators.required]),
      IsWeekly: new FormControl(data.IsWeekly || false, [Validators.required]),
      Comment: new FormControl(data.Comment),
    });
  }

  ngOnInit() {
    this.getServiceTypes();
  }

  getServiceTypes() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/ServiceTypes`)
      .subscribe(expenseTypes => (this.serviceTypes = expenseTypes));
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
