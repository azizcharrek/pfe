import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Formation } from './formation';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FormationService {
 // url = 'http://localhost:55840/Api/Employee';
 url = "http://localhost:55840/Api/Employee";
 urll=environment.urlbase
  constructor(private http: HttpClient) { }  
  getAllFormation(): Observable<Formation[]> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json','No-Auth':'True'}) };  
    return this.http.get<Formation[]>(this.url + '/AllFormationDetails');  
    //+ '/AllFormationDetails'
  }  
  getFormationById(formationid: string): Observable<Formation> {  
    return this.http.get<Formation>(this.url +'/GetFormationDetailsById/' + formationid);  
    //'/GetFormationDetailsById/'
  }  
  createFormation(Formation: Formation): Observable<Formation> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json','No-Auth':'True'}) };  
    return this.http.post<Formation>(this.url + '/InsertFormationDetails',  
    Formation, httpOptions);  
    //'/InsertFormationDetails/'
  }  
  updateFormation(formation: Formation): Observable<Formation> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Formation>(this.url + '/UpdateformationDetails',  
    formation, httpOptions);  
  }  
  ValideFormation(formation: Formation): Observable<Formation> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Formation>(this.url + '/Valideformation',  
    formation, httpOptions);  
  }  
  deleteFormationById(formationid: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeleteFormationDetails?id=' +formationid,  
 httpOptions);  
  }  
}  
