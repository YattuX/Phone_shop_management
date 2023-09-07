import { Component, Optional, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-customer',
  templateUrl: './customer.dialog.html',
})
export class CustomerDialog{
  form : FormGroup;
  constructor(
    public dialogRef: MatDialogRef<CustomerDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder
  ){
    this.form = this._formBuilder.group({
      name:[null, Validators.required, Validators.maxLength(100), Validators.minLength(2)],
      lastName:[null, Validators.required, Validators.maxLength(100), Validators.minLength(2)],
      phoneNumber:[null,Validators.maxLength(9)],
      whatsappNumber:[null, Validators.maxLength(9)],
      adress:[null, Validators.required, Validators.maxLength(100), Validators.minLength(100)],
      isClientEnGros: [false],
    })
  }
}
