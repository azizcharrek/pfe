import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material'; 
import { Component, OnInit, ViewChild } from '@angular/core';  
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';   
import {  Formation } from '../formation';  
import { FormationService } from '../formation.service';

import Swal from 'sweetalert2'

@Component({  
  selector: 'app-formation',  
  templateUrl: './formation.component.html',  
  styleUrls: ['./formation.component.css']  
})  
export class formationComponent implements OnInit {  
  
  dataSaved = false;  
  FormationForm: any;  
  allFormations: Observable<Formation[]>;  
  FormationIdUpdate = null;  
  massage = null;
 
 

  constructor(private formbulider: FormBuilder, private FormationService:FormationService) { 
     }
  
  ngOnInit() { 
    
    this.FormationForm = this.formbulider.group({  
      titre: ['', [Validators.required]], 
      specialite: ['', [Validators.required]],  
      description: ['', [Validators.required]],  
      duree: ['', [Validators.required]],  
      certification: ['', [Validators.required]],  
      prix: ['', [Validators.required]],  
       
    
    }); 
    this.loadAllFormations ();  
  } 
  Valideformation(){
    
  } 
  loadAllFormations() {  
    this.allFormations = this.FormationService.getAllFormation();  
  }  
  onFormSubmit() {  
    this.dataSaved = false;  
    const formation = this.FormationForm.value;  
    this.CreateFormations (formation);  
    this.FormationForm.reset();  
  }  
  loadFormationToEdit(employeeId: string) {  
    this.FormationService.getFormationById(employeeId).subscribe(Formation=> {  
      this.massage = null;  
      this.dataSaved = false;  
      this.FormationIdUpdate = Formation.id_form;  
      this.FormationForm.controls['titre'].setValue(Formation.titre);  
      this.FormationForm.controls['specialite'].setValue(Formation.specialite);  
      this.FormationForm.controls['description'].setValue(Formation.description);  
      this.FormationForm.controls['duree'].setValue(Formation.duree);  
      this.FormationForm.controls['certification'].setValue(Formation.certification);  
      this.FormationForm.controls['prix'].setValue(Formation.prix);  
    });  
  
  }  
  CreateFormations(Formation: Formation) {  
    if (this.FormationIdUpdate == null) {  
      this.FormationService.createFormation(Formation).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.massage = 'Record saved Successfully';  
          this.loadAllFormations();  
          this.FormationIdUpdate = null;  
          this.FormationForm.reset();  
        }  
      );  
    } else {  
      Formation.id_form = this.FormationIdUpdate;  
      this.FormationService.updateFormation(Formation).subscribe(() => {  
        this.dataSaved = true;  
        this.massage = 'Record Updated Successfully';  
        this.loadAllFormations();  
        this.FormationIdUpdate = null;  
        this.FormationForm.reset();  
      });  
    }  
  }   
  deleteFormation(employeeId: string) {  
    Swal.fire({
      title: 'Are you sure you want to delete this ?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
      confirmButtonColor: '#dc3545',
      cancelButtonColor: '#17a2b8'
    }).then((result) => {
      if (result.value) {

        this.FormationService.deleteFormationById(employeeId).subscribe(() => {  
          this.dataSaved = true;  
          this.massage = 'Record Deleted Succefully';  
          this.loadAllFormations();  
          this.FormationIdUpdate = null;  
          this.FormationForm.reset();  
      
        });  
       
        Swal.fire(
          'Deleted!',
          '',
          'success'
        )
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          '',
          'error'
        )
      }
    })
   /* if (confirm("Are you sure you want to delete this ?")) {   
    this.FormationService.deleteFormationById(employeeId).subscribe(() => {  
      this.dataSaved = true;  
      this.massage = 'Record Deleted Succefully';  
      this.loadAllFormations();  
      this.FormationIdUpdate = null;  
      this.FormationForm.reset();  
  
    });  
  }  */
}  
  resetForm() {  
    this.FormationForm.reset();  
    this.massage = null;  
    this.dataSaved = false;  
  }  
 
    } 
    
  