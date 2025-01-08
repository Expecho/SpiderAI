import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatapiService {

  private apiUrl = 'http://localhost:5280/api';

  constructor(private http: HttpClient) { }

  getData(prompt: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/chat?message=${prompt}&conversationId=94ab15aa-946b-402c-9183-5794c99c0bc5`);
  }
}
