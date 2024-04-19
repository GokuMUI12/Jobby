import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
@Injectable()
 export class ErrorInterceptor implements HttpInterceptor {
  
  constructor(private router: Router) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
    .pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = this.handleError(error);
        return throwError(() => new Error(errorMessage));
        console.log(errorMessage)
      })
    )
  }
  private handleError = (error: HttpErrorResponse) : any => {
    if(error.status === 404){
      return this.handleNotFound(error);
    }
    else if(error.status === 400){
      return this.handleBadRequest(error);
    }
    else if(error.status === 401) {
      return this.handleUnauthorized(error);
    }
  }
  
  private handleNotFound = (error: HttpErrorResponse): string => {
    this.router.navigate(['/404']);
    return error.message;
  }
  
  private handleBadRequest = (error: HttpErrorResponse): string => {
    if(this.router.url === '/account/register'){
      let message = '';
      const values = Object.values(error.error.errors);
      values.map((m: any) => {
         message += m + '<br>';
      })
  
      return message.slice(0, -4);
    }
    else{
      return error.error ? error.error : error.message;
    }
  }
  private handleUnauthorized = (error: HttpErrorResponse) => {
    if(this.router.url === '/account/login') {
      return 'Authentication failed. Wrong Username or Password';
    }
    else {
      this.router.navigate(['/account/login']);
      return error.message;
    }
  }
}
