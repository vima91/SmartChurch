import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-withdraw-from-bank',
  templateUrl: './withdraw-from-bank.component.html',
  styleUrls: ['./withdraw-from-bank.component.scss']
})
export class WithdrawFromBankComponent implements OnInit {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<WithdrawFromBankComponent>) { }

  ngOnInit() {
    this.form = this.fb.group({
      WithdrawalAmount: new FormControl('', [Validators.required])    
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
