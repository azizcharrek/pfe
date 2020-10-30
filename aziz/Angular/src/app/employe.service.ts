import { Injectable, Type } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Employe } from './employe';
import { type } from './Type';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeService {

  url = 'http://localhost:55840/Api/Employee'; 
 urll=environment.urlbase

  // urll+"/Employee"
  listType : type[]; 
  constructor(private http: HttpClient) { }  

  posteFile(fileToUpload: File){
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload,fileToUpload.name)
    //formData.append('Employee',employee);
    return this.http.post(this.url + '/Upload',formData)
  }
  
  getAllEmployee() {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.get<Employe[]>(this.urll +'/AllEmployeeDetails' );  
    //+ '/AllEmployeeDetails'
  } 
  TypeByEmployee(TypeID:string) {  
    return this.http.get(this.url + 'TypeDetails/' + TypeID).toPromise().then(result=>this.listType = result as type[])  
   }  
  GetAllFormateurEmployees(): Observable<Employe[]> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.get<Employe[]>(this.url );  
    //+ '/GetAllFormateurEmployees'
  }  
  getEmployeeById(employeId: string): Observable<Employe> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<Employe>(this.urll +'/GetEmployeeDetailsById/' + employeId);  
    //'/GetEmployeeDetailsById/'
  }  
  createEmployee(employe: Employe): Observable<Employe> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Employe>(this.url + '/InsertEmployeeDetails',  
    employe, httpOptions) 
    //'/InsertEmployeeDetails/'
    }
   /*  postFile(fileToUpload: File) {
      const endpoint = 'http://localhost:28101/api/UploadImage';
      const formData: FormData = new FormData();  
      formData.append('Image', fileToUpload, fileToUpload.name);
     // formData.append('ImageCaption', caption);
      return this.http
        .post(endpoint, formData);
    }
   */
  
  updateEmployee(employe: Employe): Observable<Employe> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Employe>(this.url + '/UpdateEmployeeDetails',  
    employe, httpOptions);  
  }  
  deleteEmployeeById(employeid: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeleteEmployeeDetails?id=' +employeid,  
 httpOptions);  
  }  
}  
