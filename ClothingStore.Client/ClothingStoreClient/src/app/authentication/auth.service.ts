import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  registerPath: string = environment.apiUrl + "auth/register";
  loginPath: string = environment.apiUrl + "auth/login";

  constructor(private http: HttpClient) { }

  register(data) : Observable<any>{
    return this.http.post(this.registerPath, data);
  }

  login(data) : Observable<any>{
    return this.http.post(this.loginPath, data);
  }

  saveToken(token){
    localStorage.setItem('token', token);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  isAuthenticated()
  {
    if (this.getToken()) {
      return true;
    }
    return false;
  }
}
