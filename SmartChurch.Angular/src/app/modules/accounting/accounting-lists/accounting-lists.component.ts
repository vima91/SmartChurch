import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpService } from 'src/app/API/http.service';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig, MatTableDataSource, MatPaginator, MatSort, MatInput } from '@angular/material';
import { DepoisteToBankComponent } from '../components/depoiste-to-bank/depoiste-to-bank.component';
import { IDepoisteToBank } from "../interfaces/depoiste-to-bank.interface";
import { ToastrService } from 'ngx-toastr';
import { WithdrawFromBankComponent } from '../components/withdraw-from-bank/withdraw-from-bank.component';
import { CreateExpenseComponent } from '../components/create-expense/create-expense.component';
import { IExpense } from '../interfaces/expense.interface';

@Component({
  selector: 'app-accounting-lists',
  templateUrl: './accounting-lists.component.html',
  styleUrls: ['./accounting-lists.component.scss']
})

export class AccountingListsComponent implements OnInit {
  displayedColumns: string[] = ['ExpenseTypeName', 'Comment', 'Amount', 'ExpenseDate'];
  dataSource: MatTableDataSource<IExpense>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  isLoading = false;
  balance: any = {};
  searchForm: any = { from: "", to: "" };
  expensesList: IExpense[] = [];
  @ViewChild('toInput', { static: false }) toInput: MatInput;
  @ViewChild('fromInput', { static: false }) fromInput: MatInput;


  constructor(
    private accountingService: HttpService,
    private notificationUtil: ToastrService,
    private dialog: MatDialog) {

  }

  ngOnInit() {
    this.getBalance();
    this.getExpenses();
  }


  getExpenses() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IExpense>();
    this.accountingService.getAllWithSearchCriteria(`${environment.BASE_URL}/api/Accounting/GetExpenses`, this.searchForm)
      .subscribe(expensesList => {
        this.expensesList = <IExpense[]>expensesList;
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(this.expensesList);
        this.isLoading = !this.isLoading;
      });
  }

  resetForm() {
    this.fromInput.value = '';
    this.toInput.value = '';
    this.searchForm = { from: "", to: "" }
  }
  /**
   * Set the paginator and sort after the view init since this component will
   * be able to query its view for the initialized paginator and sort.
   */
  ngAfterViewInit() {

    setTimeout(() => {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, 1000);
  }

  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }

  getBalance() {
    this.accountingService.getItemById(`${environment.BASE_URL}/api/accounting/getbalances`)
      .subscribe((balance) => {
        this.balance = balance;
      });
  }

  openDepoisteToBank() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    this.dialog.open(DepoisteToBankComponent, dialogConfig).afterClosed().subscribe((result: IDepoisteToBank) => {
      if (result != undefined) {
        this.saveDepoisteToBank(result);
      }
    });
  }

  openWithdrawFromBank() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    this.dialog.open(WithdrawFromBankComponent, dialogConfig).afterClosed().subscribe((result: number) => {
      if (result != undefined) {
        this.saveWithdrawalAmount(result);
      }
    });
  }

  addExpense() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';
    this.dialog.open(CreateExpenseComponent, dialogConfig).afterClosed().subscribe((result: IExpense) => {
      if (result != undefined) {
        this.saveExpense(result);
      }
    });

  }

  saveDepoisteToBank(depoiste: IDepoisteToBank) {
    this.accountingService.create(`${environment.BASE_URL}/api/accounting/deposittobank`, depoiste)
      .subscribe(() => {

        this.notificationUtil.success('Sucess', `Saved successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getBalance();
      });
  }

  saveWithdrawalAmount(amount: number) {
    this.accountingService.create(`${environment.BASE_URL}/api/accounting/withdrawfrombanktochurch`, amount)
      .subscribe(() => {

        this.notificationUtil.success('Sucess', `Saved successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getBalance();
      });
  }


  saveExpense(expense: IExpense) {
    this.accountingService.create(`${environment.BASE_URL}/api/accounting/createexpense`, expense)
      .subscribe(() => {

        this.notificationUtil.success('Sucess', `Saved successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getBalance();
      });
  }

}
