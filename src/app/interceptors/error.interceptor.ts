import {
  HttpErrorResponse,
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { GlobalErrorHandlingService } from '../services/global-error-handling/global-error-handling.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private errorService: GlobalErrorHandlingService) {}
  token = localStorage.getItem('jwt_token');
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const authToken = this.token;

    const authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`,
      },
    });

    return next.handle(authReq).pipe(
      catchError((err: any) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
            console.error('Unauthorized request:', err);
          } else {
            console.error('HTTP error:', err);
          }
        } else {
          console.error('An error occurred:', err);
        }

        this.errorService.handleError(err);

        return throwError(() => err);
      })
    );
  }
}
