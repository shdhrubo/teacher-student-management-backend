import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root',
})
export class GlobalErrorHandlingService {
  constructor(private toaster: ToastrService) {}

  handleError(err: HttpErrorResponse) {
    let errorMessage: string = 'Something went wrong!';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.error.message}`;
    } else {
      switch (err.status) {
        case 400:
          errorMessage = `${err.status}: Bad request`;
          break;

        case 401:
          errorMessage = `${err.status}: You are unauthorize to do this action`;
          break;

        case 403:
          errorMessage = `${err.status}: You do not have permission to access the requested resource`;
          break;

        case 404:
          errorMessage = `${err.status}: The requested resource does not exists`;
          break;

        case 500:
          errorMessage = `${err.status}: Internal server error`;
          break;

        case 503:
          errorMessage = `${err.status}: The requested service is not available`;
          break;

        default:
          errorMessage = `Something went wrong!`;
      }
    }

    this.toaster.error(errorMessage);
    console.error(errorMessage);
  }
}
