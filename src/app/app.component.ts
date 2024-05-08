import { Component } from '@angular/core';
import { LoadingService } from './services/loading-service/loading-service.service';
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'sample-application';
  isLoading: Observable<boolean>;

  constructor(
    private loadingService: LoadingService,
    public auth: AuthService
  ) {
    this.isLoading = this.loadingService.getLoading();
  }
  ngOnInit(): void {
    this.auth.idTokenClaims$.subscribe((claims) => {
      console.log(claims);
      const token = claims?.__raw;
      if (token) {
        localStorage.setItem('jwt_token', token);
      }
    });
  }
  logout(): void {
    localStorage.removeItem('jwt_token');
    this.auth.logout();
  }
}
