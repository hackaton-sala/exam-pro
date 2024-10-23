import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from '../../models/application/user';

@Injectable({
  providedIn: 'root'
})
export class GrammarService {

  private url = `${environment.urlPy}/${'generate-questions'}`;

  constructor(private httpClient: HttpClient) { }

  generateQuestions(prompt: string): Observable<any> {
    const body = { };
    return this.httpClient.post<any>(this.url, body);
  }
}
