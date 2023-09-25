import { Component, Optional, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { KadaService } from 'src/app/shared/services/kada.service';

@Component({
  templateUrl: './couleur.dialog.html',
})
export class CouleurDialog {
  form: FormGroup;
  showSpinner: boolean = false;
  constructor(
    public dialogRef: MatDialogRef<CouleurDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ) {
    this.form = this._formBuilder.group({
      name: [data?.name, [Validators.required, Validators.maxLength(50), Validators.minLength(2)]],
      codeCouleur:[data?.codeCouleur??'']
    })
  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        const data = { ...this.form.value };
        this._kadaService.createCouleur(data)
          .subscribe({
            next: (response) => {
              this.dialogRef.close(true);
              this._toastr.success("Couleur ajoutée avec succès!");
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
        this._kadaService.updateCouleur({ ...this.form.value,id:this.data?.id })
          .subscribe({
            next: () => {
              this.dialogRef.close(true);
              this._toastr.success("Couleur modifiée avec succès!");
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
