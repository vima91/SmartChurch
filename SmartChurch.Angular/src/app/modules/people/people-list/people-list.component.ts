import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { HttpService } from '../../../API/http.service';
import { environment } from '../../../../environments/environment';
import { IPerson } from '../interfaces/person.interface';
import { ToastrService } from 'ngx-toastr';


/**
 * @title Data table with sorting, pagination, and filtering.
 */
@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.scss']
})
export class PeopleListComponent implements OnInit {
  displayedColumns: string[] = ['Name', 'PhoneNumber', 'Email', 'delete'];
  dataSource: MatTableDataSource<IPerson>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  persons: IPerson[] = [];
  isLoading = false;

  constructor(private peopleService: HttpService, private notificationUtil: ToastrService) {

  }

  ngOnInit(): void {

    this.getPersons();
  }

  getPersons() {
    this.isLoading = false;
    this.dataSource = new MatTableDataSource<IPerson>();
    this.peopleService.getAll(`${environment.BASE_URL}/api/person/persons`)
      .subscribe(persons => {
        this.persons = persons;
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(persons);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;  
        this.isLoading = !this.isLoading;
      });
  }

  applyFilter($event) {
    this.dataSource.filter = $event.target.value.trim().toLowerCase();
  }

  removePerson(person: IPerson) {
    this.peopleService.delete(`${environment.BASE_URL}/api/person/deleteperson`, person)
      .subscribe(() => {

        this.notificationUtil.success('Success', `${person.Name} is Deleted successfully `, {
          positionClass: 'toast-bottom-right'
        });
        this.getPersons();
      });
  }
  setDefaultImage(row: IPerson) {
    row.Picture = "assets/images/No_Image_Available.jpg";
  }
}
