import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { formationComponent } from './formation/formation.component';
import { AuthGuard } from './auth/auth.guard';
import { employeComponent } from './employe/employe.component';
import { Component } from '@angular/core';
import { LoginGuard } from './auth/login.guard';

export const appRoutes: Routes = [
    {
        path: '', component: HomeComponent, canActivate: [AuthGuard],
        children:
            [
                { path: 'formation', component: formationComponent },
                { path: 'employee', component: employeComponent }
            ]
    },
    {
        path: 'login', component: SignInComponent
    },
    {
        path: 'signup', component: SignUpComponent//,
    },
    {
        path : '**', redirectTo : ''
    }
    /* {
         path: 'formation', component: formationComponent,
         children: [{ path: '', component: formationComponent }]
     },
     { path: '', redirectTo: '/login', pathMatch: 'full' },
     {
         path:'employee',component:employeComponent,
         children: [{ path: 'Employee', component: employeComponent }]
     },*/
]; 