import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-delete-teacher-dialog',
  templateUrl: './delete-teacher-dialog.component.html',
  styleUrl: './delete-teacher-dialog.component.css',
})
export class DeleteTeacherDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteTeacherDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onCancelClick(): void {
    this.dialogRef.close(false);
  }

  onConfirmClick(): void {
    this.dialogRef.close(true);
  }
}
