import { BrowserModule } from '@angular/platform-browser';  
import { NgModule } from '@angular/core'; 
import { EmployeService } from './employe.service';  
import { FormsModule, ReactiveFormsModule } from '@angular/forms';  
import { HttpClientModule, HttpClient } from '@angular/common/http';  
import { MatSliderModule } from '@angular/material/slider';
import {  
  MatButtonModule, MatMenuModule, MatDatepickerModule,MatNativeDateModule , MatIconModule, MatCardModule, MatSidenavModule,MatFormFieldModule,  
  MatInputModule, MatTooltipModule, MatToolbarModule, MatStepperModule,MatDialogModule
} from '@angular/material';  
import { MatRadioModule } from '@angular/material/radio';  
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  
//import { AngularmaterialModule } from './material/angularmaterial/angularmaterial.module';  
import { AppRoutingModule } from './app-routing.module';  
import { AppComponent } from './app.component';  
import {  HTTP_INTERCEPTORS } from '@angular/common/http';
import { employeComponent, DialogOverviewExampleDialog } from './employe/employe.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { HomeComponent } from './home/home.component';
import { formationComponent } from './formation/formation.component';
import { RFormationComponent } from './r-formation/r-formation.component';  
import { FormationService } from './formation.service';


import { RouterModule } from '@angular/router'
import { AuthInterceptor } from './auth/auth.interceptor';

import { UserService } from './shared/user.service';
import { AuthGuard } from './auth/auth.guard';
import { ToastrModule } from 'ngx-toastr';
import { UserComponent } from './user.component';
import { appRoutes } from './routes';

import { NgxPaginationModule } from 'ngx-pagination';



@NgModule({  
  declarations: [  
    AppComponent,  
    employeComponent, SignInComponent, SignUpComponent, HomeComponent, formationComponent,UserComponent, RFormationComponent ,DialogOverviewExampleDialog
  ],  
  imports: [  
    NgxPaginationModule,
    BrowserModule,  
    FormsModule,  
    ReactiveFormsModule,  
    HttpClientModule,  
    BrowserAnimationsModule,  
    MatButtonModule,  
    MatMenuModule,  
    MatDatepickerModule,  
    MatNativeDateModule,  
    MatIconModule,  
    MatRadioModule,  
    MatCardModule,  
    MatSidenavModule,  
    MatFormFieldModule, 
    MatSliderModule, 
    MatInputModule,  
    MatTooltipModule,  
    MatToolbarModule, 
    MatStepperModule,
    MatDialogModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
    //AngularmaterialModule,  
    AppRoutingModule  
  ],  
  providers: [HttpClientModule, EmployeService,MatDatepickerModule,UserService,],  
  bootstrap: [AppComponent],
  entryComponents : [DialogOverviewExampleDialog]
})  
export class AppModule { } 