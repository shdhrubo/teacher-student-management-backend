import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-teachers-home',
  templateUrl: './teachers-home.component.html',
  styleUrl: './teachers-home.component.css',
})
export class TeachersHomeComponent {
  constructor(public auth: AuthService) {}
  handleButtonClick() {
    console.log('Button clicked!');
  }
}
