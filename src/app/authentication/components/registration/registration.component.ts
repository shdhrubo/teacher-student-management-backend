import { Component } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',
})
export class RegistrationComponent {
  name: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  submitForm() {
    if (this.password !== this.confirmPassword) {
      alert('Passwords do not match!');
      return;
    }
    console.log('success');
  }
}
