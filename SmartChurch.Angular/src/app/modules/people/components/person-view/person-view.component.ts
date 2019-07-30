import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { HttpService } from '../../../../API/http.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IPerson } from '../../interfaces/person.interface';

@Component({
  selector: 'app-person-view',
  templateUrl: './person-view.component.html',
  styleUrls: ['./person-view.component.scss']
})
export class PersonViewComponent implements OnInit, OnDestroy {
  baptismTypes: any[];
  residenceCountries: any[];
  homeCountries: any[];
  expenseTypes: any[];
  grades: any[];
  maritalStatus: any[];
  marriageTypes: any[];
  religiousTypes: any[];

  newAvatarImagePath = 'assets/images/No_Image_Available.jpg';
  newMarriageCertificateImagePath = 'assets/images/No_Image_Available.jpg';
  newBaptismCertificateImagePath = 'assets/images/No_Image_Available.jpg';

  personForm: FormGroup;

  btnActionTest: string;
  person: IPerson;
  isUpdate: boolean;
  private id: number;
  private sub$: any;

  @Input('isNew')
  set isNew(value: boolean) {
    this.isUpdate = value;
    this.btnActionTest = value ? 'Create Person' : 'Update Person';
  }

  constructor(
    private personService: HttpService,
    private notificationUtil: ToastrService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {

    this.sub$ = this.route.params.subscribe(params => {
      if (params && params.id) {
        this.id = +params.id; // (+) converts string 'id' to a number
        this.getCurrentPerson(this.id);
      }
    });
  }

  ngOnInit() {
    this.getInfo();
    this.buildPersonForm();
  }

  getCurrentPerson(id: number) {

    this.personService.getItemById(`${environment.BASE_URL}/api/person/person/${id}`)
      .subscribe((person: IPerson) => {
        this.person = person;
        this.personForm.patchValue(person);
        if (person.Picture !== null) {
          this.newAvatarImagePath = person.Picture;
        }
        if (person.BaptismCertificationPic !== null) {
          this.newBaptismCertificateImagePath = person.BaptismCertificationPic;
        }
        if (person.MarriageCertificatePic !== null) {
          this.newMarriageCertificateImagePath = person.MarriageCertificatePic;
        }
      });
  }

  ngOnDestroy() {
    this.sub$.unsubscribe();
  }


  private getInfo() {
    // getBaptismTypes
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/BaptismTypes`)
      .subscribe(baptismTypes => (this.baptismTypes = baptismTypes));
    // getCounties
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/countries`)
      .subscribe(countries => (this.homeCountries = this.residenceCountries = countries));
    // getExpenseTypes
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/ExpenseTypes`)
      .subscribe(expenseTypes => (this.expenseTypes = expenseTypes));
    // getGrades
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/Grades`)
      .subscribe(grades => (this.grades = grades));
    // Get MaritalStatuses
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/MaritalStatuses`)
      .subscribe(maritalStatus => (this.maritalStatus = maritalStatus));
    // Get marriage types
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/marriagetypes`)
      .subscribe(marriageTypes => (this.marriageTypes = marriageTypes));
    // Get Religious Backgrounds
    this.personService
      .getAll(`${environment.BASE_URL}/api/settings/religiousbackgrounds`)
      .subscribe(religiousTypes => (this.religiousTypes = religiousTypes));
  }

  uploadProfileImage($event: Event) {
    // @ts-ignore
    if ($event.target.files && $event.target.files[0]) {
      // @ts-ignore
      const file = $event.target.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = onload => {
        // called once readAsDataURL is completed
        // @ts-ignore
        this.newAvatarImagePath = onload.target.result;
        this.personForm.patchValue({
          Picture: this.newAvatarImagePath
        });
      };
    }
  }

  uploadBaptismCertificateImage($event: Event) {
    // @ts-ignore
    if ($event.target.files && $event.target.files[0]) {
      // @ts-ignore
      const file = $event.target.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = onload => {
        // called once readAsDataURL is completed
        // @ts-ignore
        this.newBaptismCertificateImagePath = onload.target.result;
        this.personForm.patchValue({
          BaptismCertificationPic: this.newBaptismCertificateImagePath
        });
      };
    }
  }

  uploadMarriageCertificateImage($event: Event) {
    // @ts-ignore
    if ($event.target.files && $event.target.files[0]) {
      // @ts-ignore
      const file = $event.target.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = onload => {
        // called once readAsDataURL is completed
        // @ts-ignore
        this.newMarriageCertificateImagePath = onload.target.result;
        this.personForm.patchValue({
          MarriageCertificatePic: this.newMarriageCertificateImagePath
        });
      };
    }
  }

  private buildPersonForm() {
    this.personForm = this.formBuilder.group({
      Name: [null],
      ConfessionFatherName: [null],
      BaptismTypeId: [null],
      Email: [null, Validators.compose([Validators.required])],
      PhoneNumber: [null],
      WhatsappNumber: [null],
      FacebookLink: [null],
      Picture: [null],
      Comments: [null],
      Birthday: [null],
      GradeId: [null],
      Job: [null],
      MaritalStatusId: [null],
      MarriageAnniversary: [null],
      Address: [null],
      Weekends: [null],
      Qualifications: [null],
      ReligiousBackgroundId: [null],
      CountryOfResidenceId: [null],
      HomeCountryId: [null],
      IsServant: [false],
      LastVisitDate: [null],
      BaptismCertificationPic: [null],
      MarriageCertificatePic: [null],
      MarriageTypeId: [null],
      LastVisitYearOfMarriageAnniversary: [null],
      LastVisitYearOfBirthday: [null]
    });
  }

  createOrUpdatePerson(person: any) {
    this.clean(person);
    if (!this.isUpdate) {
      return this.personService.update(`${environment.BASE_URL}/api/person/updateperson/${this.person.Id}`, person)
        .subscribe((resp) => {
          this.router.navigate(['/people']);
        });
    }
    return this.personService.create(`${environment.BASE_URL}/api/person/createperson`, person)
      .subscribe((resp) => {
        this.router.navigate(['/people']);
      });
  }

  private clean(obj) {
    for (const propName in obj) {
      if (obj.hasOwnProperty(propName)) {
        if (obj[propName] === null || obj[propName] === undefined) {
          delete obj[propName];
        }
      }
    }
  }
}
