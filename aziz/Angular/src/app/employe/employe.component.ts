import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { FormBuilder, Validators, Form } from '@angular/forms';
import { Observable } from 'rxjs';
import { EmployeService } from '../employe.service';
import { Employe } from '../employe';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-employee',
  templateUrl: './employe.component.html',
  styleUrls: ['./employe.component.css']
})
export class employeComponent implements OnInit {
  value = '';
  
  loading: boolean = true;
  p: number = 1;
  p2: number = 1;
  dataSaved = false;
  employeeForm: any;
  allEmployees: Employe[];
  employeeIdUpdate = null;
  massage = null;
  imageUrl: string = "/assets/img/default-image.png";
  fileToUpload: File = null;

  constructor(
    private formbulider: FormBuilder,
    private employeService: EmployeService,
    public dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.loading = true;
    this.employeeForm = this.formbulider.group({
      nom: ['', [Validators.required]],
      prenom: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      date_de_naissance: ['', [Validators.required]],
      type: ['', [Validators.required]],
      cin: ['', [Validators.required]],
      adress: ['', [Validators.required]],
      departement: ['', [Validators.required]],
      specialite: ['', [Validators.required]],
      Image: [''],

      /*  formation: ['',[Validators.required]] , */

    });

    this.loadAllEmployees();
  }
  onEnter(value: string)
   { this.value = value; }
  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const image = event.target.files[0];
      this.employeeForm.get('image').setValue(image);
    }
  }
  /*  OnSubmit(Image){
     this.employeService.postFile(this.fileToUpload).subscribe(
       data =>{
         console.log('done');
         
         Image.value = null;
         this.imageUrl = "/assets/img/default-image.png";
       }
     );} */

  loadAllEmployees() {
    this.loading = true;
    this.employeService.getAllEmployee().subscribe((res) => {
      this.allEmployees = [];
      console.log("1", res)
      this.allEmployees = res as Employe[];
      this.loading = false;
    });
  }
  /* loadEmployee(employeeId){
    this.loading = true;
    this.employeService.getEmployeeById().subscribe((res) => {
      this.allEmployees = [];
      console.log("1", res)
      this.allEmployees = res as Employe[];
      this.loading = false;
  });} */
  loadAllFormateurEmployees() {
    this.employeService.GetAllFormateurEmployees().subscribe((res) => {
      console.log("2", res)
      this.allEmployees = res;
    })
  }

  name: string = "";
  last: string = "";

  edit(Obj) {
    const employee = this.employeeForm.value;
     const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      width: "500px",
      data: Obj 
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.last = result;
    });
  }

  onFormSubmit(Image) {
    this.dataSaved = false;
    // var Employe = new Employe();

    // Employe= <Employe>this.employeeForm.value; 

    const employee = this.employeeForm.value;
    //this.CreateEmployee(employee);  
    this.employeService.posteFile(this.fileToUpload).subscribe(
      data => {
        // console.log('done');
        console.log("data", data)
        employee.image = data;
        this.employeService.createEmployee(employee).subscribe((res) => {
          console.log("res", res)
          Image.value = null;
          this.imageUrl = "/assets/img/default-image.png";
        })
      }
    );
    // this.employeeForm.OnSubmit(Image);
    this.employeeForm.reset();
  }
  editEmploye(employe){
    this.dataSaved = false;
    const employee = this.employeeForm.value;
  }

  openPopup() {
    document.querySelector('#m').classList.add('is-active')
    console.log("opned")
  }

  closePopup() {
    document.querySelector('#m').classList.remove('is-active')
  }

  loadEmployeeToEdit(employeeId: string) {
    this.employeService.getEmployeeById(employeeId).subscribe(employe => {
      this.massage = null;
      this.dataSaved = false;
      this.employeeIdUpdate = employe.id_emp;
      this.employeeForm.controls['nom'].setValue(employe.nom);
      this.employeeForm.controls['prenom'].setValue(employe.prenom);
      this.employeeForm.controls['Email'].setValue(employe.Email);
      this.employeeForm.controls['date_de_naissance'].setValue(employe.date_de_naissance);
      this.employeeForm.controls['type'].setValue(employe.type);
      this.employeeForm.controls['image'].setValue(employe.image);
      this.employeeForm.controls['cin'].setValue(employe.cin);
      this.employeeForm.controls['adress'].setValue(employe.adress);
      this.employeeForm.controls['departement'].setValue(employe.departement);
      this.employeeForm.controls['specialite'].setValue(employe.specialite);
      /*  this.employeeForm.controls['formation'].setValue(employe.formation);   */
    });

  }
  CreateEmployee(employee: Employe) {
    if (this.employeeIdUpdate == null) {
      this.employeService.createEmployee(employee).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          this.loadAllEmployees();
          this.employeeIdUpdate = null;
          this.employeeForm.reset();
        }
      );
    } else {
      employee.id_emp = this.employeeIdUpdate;
      this.employeService.updateEmployee(employee).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        this.loadAllEmployees();
        this.employeeIdUpdate = null;
        this.employeeForm.reset();
      });
    }
  }
  deleteEmployee(employeeId: string) {
    if (confirm("Are you sure you want to delete this ?")) {
      this.employeService.deleteEmployeeById(employeeId).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Deleted Succefully';
        this.loadAllEmployees();
        this.employeeIdUpdate = null;
        this.employeeForm.reset();

      });
    }
  }
  resetForm() {
    this.employeeForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }

}

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog-overview-example-dialog.html',
})
export class DialogOverviewExampleDialog implements OnInit {
  
  name: string = "";

  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
    console.log("init",this.data)
  }

  onSave(){
    console.log("saved")
    this.onNoClick();
  }

}