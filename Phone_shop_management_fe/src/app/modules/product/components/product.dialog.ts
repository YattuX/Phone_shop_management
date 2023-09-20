import { Component, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-product.dialog',
  templateUrl: './product.dialog.html',
})
export class ProductDialog {
  showSpinner: boolean = false;

    constructor(
      public dialogRef: MatDialogRef<ProductDialog>,
      @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    ){

    }
}
