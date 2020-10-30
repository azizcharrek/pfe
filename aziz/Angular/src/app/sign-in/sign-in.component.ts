import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isLoginError : boolean = false;
  message : string = "";
  constructor(private userService : UserService,private router : Router) { }

  ngOnInit() {
    if(localStorage.getItem('userToken') != null){
      this.router.navigateByUrl('/');
    }
    this.message ="";
  }

  OnSubmit(userName,password){
    this.userService.userAuthentication(userName,password).subscribe((data : any)=>{
      console.log("res", data)
      if(data["error"] == "email"){
        this.message = "email ivalid"
      }else if(data["error"] == "password"){
        this.message = "mot de passe invalid"
      }else{
        this.message =""
        localStorage.setItem('userToken',data.access_token);
        this.router.navigate(['/']);
        
      }
    },
    (err : HttpErrorResponse)=>{
      console.log("err", err)
      this.isLoginError = true;
    });
  }

}
