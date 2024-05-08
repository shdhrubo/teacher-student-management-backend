import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  // constructor(public auth: AuthService) {}
  // ngOnInit(): void {
  //   this.auth.idTokenClaims$.subscribe((claims) => {
  //     const token = claims?.__raw;
  //     if (token) {
  //       localStorage.setItem('jwt_token', token);
  //     }
  //   });
  // }
}
