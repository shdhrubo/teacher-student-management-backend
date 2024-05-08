import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-material-button',
  templateUrl: './material-button.component.html',
  styleUrl: './material-button.component.css',
  // standalone: true,
  // imports: [
  //   // Angular Material
  //   MatButtonModule,
  // ],
})
export class MaterialButtonComponent {
  @Input() text: string = '';
  @Input() color: string = 'primary';
  @Input() disabled: boolean = false;
  @Output() btnClick = new EventEmitter();

  onClick() {
    this.btnClick.emit();
  }
}
