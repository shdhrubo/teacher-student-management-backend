import { LoadingService } from '../services/loading-service/loading-service.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(private loadingService: LoadingService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
    this.loadingService.setLoading(true);
    return next
      .handle(request)
      .pipe(finalize(() => this.loadingService.setLoading(false)));
  }
}
