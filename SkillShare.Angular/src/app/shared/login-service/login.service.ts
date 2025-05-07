import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  client: HttpClient;
  constructor(client: HttpClient) {
    this.client = client;
  }

  login(email: string, password: string): Observable<boolean> {
    const data = { email: email, password: password };
    return this.client.post('https://localhost:7043/api/User/login', data).pipe(
      map((tokens) => {
        console.log(tokens.toString());
        return true;
      })
    );
  }
}
