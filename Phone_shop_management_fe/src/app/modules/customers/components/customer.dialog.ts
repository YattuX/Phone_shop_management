import { Component, Optional, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { KadaService } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './customer.dialog.html',
})
export class CustomerDialog{
  form : FormGroup;
  showSpinner : boolean = false;
  constructor(
    public dialogRef: MatDialogRef<CustomerDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ){
    this.form = this._formBuilder.group({
      name:[null, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      lastName:[null, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      phoneNumber:[null,Validators.maxLength(20)],
      whatsappNumber:[null, Validators.maxLength(20)],
      adress:[null, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      isClientEnGros: [false],
    })
  }

  save() {
    if (this.form.valid) {
      console.log('test')
        this.showSpinner = true;
        if (this.data?.action === 'add') {
            this._kadaService.createClient({ ...this.form.value })
                .subscribe({
                    next: (response) => {
                        this.dialogRef.close(true);
                        this._toastr.success("Client ajouté avec succès!");
                    },
                    error: (err) => {
                        this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
                        this.showSpinner = false;
                    },
                    complete: () => {
                        this.showSpinner = false;
                    }
                })
        }
    }
}
}
