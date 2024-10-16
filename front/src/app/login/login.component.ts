import { Component } from '@angular/core';
import { Login } from '../models/common/login';
import { AuthService } from '../services/common/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}
  
  public login(){
    const datosLogin: Login = {
      Email: "email",
      Password: "pass"
    };

    this.authService
      .login(datosLogin)
      .subscribe((loginCorrecto: any) => {
        if(loginCorrecto){
          console.log("login correcto")
          const { redirect } = window.history.state;
          this.router.navigateByUrl(redirect || '/')
        }else{
          console.log("mal login")
        }
      })
  }
}
