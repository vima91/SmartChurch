import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/API/http.service';

@Component({
  selector: 'app-create-expense',
  templateUrl: './create-expense.component.html',
  styleUrls: ['./create-expense.component.scss']
})
export class CreateExpenseComponent implements OnInit {
  form: FormGroup;
  expenseTypes: any[];

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CreateExpenseComponent>,
    private settingsService: HttpService) { }

  ngOnInit() {
    this.form = this.fb.group({
      ExpenseTypeId: new FormControl('', [Validators.required]),
      ExpenseDate: new FormControl(new Date(), [Validators.required]),
      Amount: new FormControl('', [Validators.required]),
      Comment: new FormControl(''),
    });
    this.getExpenseTypes();
  }

  getExpenseTypes() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/ExpenseTypes`)
      .subscribe(expenseTypes => (this.expenseTypes = expenseTypes));
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
