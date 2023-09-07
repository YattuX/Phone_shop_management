import { Component, Optional, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { KadaService } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './customer.dialog.html',
})
export class CustomerDialog {
  form: FormGroup;
  showSpinner: boolean = false;
  constructor(
    public dialogRef: MatDialogRef<CustomerDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ) {
    this.form = this._formBuilder.group({
      name: [data?.name, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      lastName: [data?.lastName, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      phoneNumber: [data?.phoneNumber, Validators.maxLength(20)],
      whatsappNumber: [data?.whatsappNumber, Validators.maxLength(20)],
      adress: [data?.adress, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      isClientEnGros: [data?.isClientEnGros],
    })
  }

  save() {
    if (this.form.valid) {
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
      } else {
        this._kadaService.updateClient(this.data?.id,{ ...this.form.value,id:this.data?.id })
          .subscribe({
            next: () => {
              this.dialogRef.close(true);
              this._toastr.success("Client modifié avec succès!");
            },
            error: (err) => {
              this._toastr.error(`Erreur! Veuillez réessayer!\n ${err.title}`);
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
