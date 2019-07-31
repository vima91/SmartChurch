import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-depoiste-to-bank',
  templateUrl: './depoiste-to-bank.component.html',
  styleUrls: ['./depoiste-to-bank.component.scss']
})
export class DepoisteToBankComponent implements OnInit {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<DepoisteToBankComponent>) { }

  ngOnInit() {
    this.form = this.fb.group({
      ReceiptNumber: new FormControl('', [Validators.required]),
      ReceiptDate: new FormControl(new Date(), [Validators.required]),
      Amount: new FormControl('', [Validators.required]),
      Comment: new FormControl(''),
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
