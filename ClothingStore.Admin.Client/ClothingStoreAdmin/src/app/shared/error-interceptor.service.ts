import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private toastr : ToastrService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        /*err.error.forEach(element => {
          this.toastr.error(element.description);
        });
        */
       console.log(err);
        return throwError(err);
      })
    )
  }

}
