import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from '../../models/application/user';

@Injectable({
  providedIn: 'root'
})
export class WritingService {

  private url = `${environment.urlPy}/${'generate-feedback'}`;

  constructor(private httpClient: HttpClient) { }

  generateFeedback(prompt: string): Observable<any> {
    const body = { prompt: prompt };
    return this.httpClient.post<any>(this.url, body);
  }
}
