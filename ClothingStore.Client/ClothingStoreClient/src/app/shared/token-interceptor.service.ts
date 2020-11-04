import { Observable } from 'rxjs';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        'Content-Type' : 'application/json',
        'Authorization': `Bearer ${this.getToken()}`
      }
    });

    return next.handle(request);
  }

  getToken() {
    return localStorage.getItem('token')
  }
}
