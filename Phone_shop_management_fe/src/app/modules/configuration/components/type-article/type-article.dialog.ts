import { Component, Optional, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { KadaService } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './type-article.dialog.html',
})
export class TypeArticleDialog {
  form: FormGroup;
  showSpinner: boolean = false;
  constructor(
    public dialogRef: MatDialogRef<TypeArticleDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ) {
    this.form = this._formBuilder.group({
      name: [data?.name, [Validators.required, Validators.maxLength(50), Validators.minLength(2)]],
    })
  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        const data = { ...this.form.value };
        this._kadaService.createTypeArticle(data)
          .subscribe({
            next: (response) => {
              this.dialogRef.close(true);
              this._toastr.success("Type d'article ajouté avec succès!");
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
        this._kadaService.updateTypeArticle({ ...this.form.value,id:this.data?.id })
          .subscribe({
            next: () => {
              this.dialogRef.close(true);
              this._toastr.success("Type d'article modifié avec succès!");
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
