import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { HttpService } from '../../../API/http.service';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.scss']
})
export class GradeComponent implements OnInit {

  grades: any[];
  currentGrade: any;

  constructor(private settingsService: HttpService, private notificationUtil: ToastrService) {}

  ngOnInit() {

    this.getGrades();
    this.resetCurrentGrade();
  }

  getGrades() {

    this.settingsService.getAll(`${environment.BASE_URL}/api/settings/Grades`)
      .subscribe(grades => (this.grades = grades));
  }

  resetCurrentGrade() {

    this.currentGrade = { Name: ''};
  }

  selectGrade(grade) {

    this.currentGrade = grade;
  }

  cancel() {

    this.resetCurrentGrade();
  }

  createGrade(grade) {

    const _grade = grade;
    this.settingsService.create(`${environment.BASE_URL}/api/settings/createGrade`, grade).subscribe(() => {

      this.notificationUtil.success('Success', `${_grade.Name} is Created successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getGrades();
      this.resetCurrentGrade();
    });
  }

  updateGrade(grade) {

    const _grade = grade;
    this.settingsService.update(`${environment.BASE_URL}/api/settings/updateGrade/${grade.Id}`, grade).subscribe(() => {

      this.notificationUtil.success('Success', `${_grade.Name} is Updated successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getGrades();
      this.resetCurrentGrade();
    });
  }

  deleteGrade(grade) {

    const _grade = grade;
    this.settingsService.delete(`${environment.BASE_URL}/api/settings/deleteGrade/${grade.Id}`, grade).subscribe(() => {

      this.notificationUtil.success('Success', `${_grade.Name} is deleted successfully `, {
        positionClass: 'toast-bottom-right'
      });
      this.getGrades();
      this.resetCurrentGrade();
    });
  }

  savedGrade(grade) {

    if (!grade.Id) {

      return this.createGrade(grade);
    }
    return this.updateGrade(grade);
  }

}
