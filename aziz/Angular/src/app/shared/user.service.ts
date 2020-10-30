import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';


@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:55840';
  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/users/register', body,{headers : reqHeader});
  }

  userAuthentication(UserName, password) {
    var data = {
      Email: UserName,
      Password:password
    }
    //"UserName=" + UserName + "&Password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'False' });
    return this.http.post(this.rootUrl + '/api/users/login', data );
  }

  /*getUserClaims(){
   return  this.http.get(this.rootUrl+'/api/GetUserClaims');
  }*/
  public getToken(): string {
      var token = localStorage.getItem('userToken')
    
    return token
  }
  public getUserClaims() {
    const token = this.getToken()
    let payload
    if (token) {
      payload = token.split('.')[1]
      payload = window.atob(payload)
      return JSON.parse(payload)
    } else {
      return null
    }
  }

  public isLoggedIn(){
   if(this.getToken() != null){
    return true;
   }
   return false;
  }

}
