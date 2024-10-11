import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscriber } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Login } from '../../models/common/login';
import { UserData } from '../../models/common/user-data';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = `${environment.url}`;

  jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) { }

  login(datosLogin: Login){
    let result = false;

    return Observable.create((observer: Subscriber<any>) =>{
      this.httpClient.post(`${this.url}/login`, datosLogin, {headers: new HttpHeaders({'Content-Type': 'application/json'})})
        .subscribe(
          (data) => {
            const response: any = data;
            if(response && response.Token) {
              const user = new UserData();
              user.Token = response.Token;
              localStorage.setItem('Usuario', JSON.stringify(user))

              result = true;
            } else {
              result = false;
            }

            observer.next(result);
            observer.complete();
          },
          (error) => {
            observer.next(result);
            observer.complete();
          }
        );
    })
  }

  logout() {
    localStorage.removeItem('User');
    this.router.navigate(['/login']);
  }

  refrescar() {
    return Observable.create((observer: Subscriber<any>) => {
      let result = false;
      const userData: UserData = JSON.parse(localStorage.getItem('Usuario') || 'null');
      let token!: string;

      if (userData) {
        token = userData.Token;
      }

      if (!token || token === '') {

        localStorage.removeItem('Usuario');
        this.router.navigate(['/login'], { state: { redirect: this.router.url } });

        observer.next(result);
        observer.complete();
      } else {
        if (!this.jwtHelper.isTokenExpired(token)) {
          const user: UserData = JSON.parse(localStorage.getItem('Usuario') || 'null');
          this.httpClient.get(`${this.url}/refrescar`, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }).subscribe(
            (data: any) => {
              const response: any = data;
              if (response && response.Token) {
                user.Token = response.Token;
                localStorage.setItem('Usuario', JSON.stringify(user));
                result = true;
                observer.next(result);
                observer.complete();
              }
            },
            () => {
              observer.next(result);
              observer.complete();
            });
        } else {
          this.logout();
          observer.next(result);
          observer.complete();
        }
      }
    });
  }
}
