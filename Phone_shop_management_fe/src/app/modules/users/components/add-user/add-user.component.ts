import { Component, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserDialog {
  constructor(
    public dialogRef: MatDialogRef<AddUserDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
}
