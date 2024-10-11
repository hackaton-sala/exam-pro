import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from '../../models/application/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private url = `${environment.url}/${'users'}`;

  constructor(private httpClient: HttpClient) { }

  public getUsuarios(): Observable<User[]> {
    return this.httpClient.get<any[]>(`${this.url}`);
  }

  public getUsuario(userId: string): Observable<User> {
    return this.httpClient.get<any>(`${this.url}/${userId}`);
  }

  public postUsuario(user: User): Observable<any> {
    return this.httpClient.post(this.url, user);
  }

  public putUsuario(userId: string, user: User): Observable<any> {
    return this.httpClient.put(`${this.url}/${userId}`, user);
  }
}
