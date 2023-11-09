import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserData } from '../models/user-data';
import { UserCredentials } from '../models/user-credentials';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService {

  private httpOptions= {
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  }

  constructor(private httpClient: HttpClient) { }

  registerUserAccount(userData: UserData): Observable<any>{
    return this.httpClient.post("https://localhost:7014/users", userData, this.httpOptions);
  }

  loginUserAccount(credentials: UserCredentials): Observable<any>{
    return this.httpClient.post("https://localhost:7014/users/login", credentials, this.httpOptions);
  }

  getUserById(id: string): Observable<any>{
    return this.httpClient.get("https://localhost:7014/users/" + id);
  }
}
