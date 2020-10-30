import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ReturnStatement } from '@angular/compiler';
@Injectable({
  providedIn : 'root'
})
export class LoginGuard implements CanActivate {
  constructor(private router : Router){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {
      console.log("user auth")
      if (localStorage.getItem('userToken') != null){
        this.router.navigate(['/e'])
        return null;
       // return false;
      }
      
      this.router.navigate(['/login']);
      //return true;
      return null;
  }
} 
 