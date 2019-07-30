import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-expense-type',
  templateUrl: './expense-type.component.html',
  styleUrls: ['./expense-type.component.scss']
})
export class ExpenseTypeComponent implements OnInit {

  expenseTypes: any[];
  currentExpenseType: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {}

  ngOnInit() {

    this.getExpenseTypes();
    this.resetCurrentExpenseType();
  }

  getExpenseTypes() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/ExpenseTypes`)
      .subscribe(expenseTypes => (this.expenseTypes = expenseTypes));
  }

  resetCurrentExpenseType() {

    this.currentExpenseType = { Name: ''};
  }

  selectExpenseType(expenseType) {

    this.currentExpenseType = expenseType;
  }

  cancel() {

    this.resetCurrentExpenseType();
  }

  createExpenseType(expenseType) {

    const _expenseType = expenseType;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createExpenseType`, expenseType).subscribe(() => {

      this.notificationUtil.success('Success', `${_expenseType.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getExpenseTypes();
      this.resetCurrentExpenseType();
    });
  }

  updateExpenseType(expenseType) {

    const _expenseType = expenseType;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updateExpenseType/${expenseType.Id}`, expenseType).subscribe(() => {

      this.notificationUtil.success('Success', `${_expenseType.Name} is Updated successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getExpenseTypes();
      this.resetCurrentExpenseType();
    });
  }

  deleteExpenseType(expenseType) {

    const _expenseType = expenseType;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deleteExpenseType/${expenseType.Id}`, expenseType).subscribe(() => {

      this.notificationUtil.success('Success', `${_expenseType.Name} is deleted successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getExpenseTypes();
      this.resetCurrentExpenseType();
    });
  }

  savedExpenseType(expenseType) {

    if (!expenseType.Id) {

      return this.createExpenseType(expenseType);
    }
    return this.updateExpenseType(expenseType);
  }
}
