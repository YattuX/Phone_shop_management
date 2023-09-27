import { Component, Optional, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { KadaService, ModelDTO, SearchDTO, TypeArticleDTO, TypeArticleDTOSearchResult } from 'src/app/shared/services/kada.service';

@Component({
  templateUrl: './modele.dialog.html',
})
export class ModeleDialog implements OnInit {
  form: FormGroup;
  showSpinner: boolean = false;
  marques:ModelDTO[];
  constructor(
    public dialogRef: MatDialogRef<ModeleDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ) {
    this.form = this._formBuilder.group({
      name: [data?.name, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      marqueId: [data?.marqueId, [Validators.required,]],
    })
  }
  ngOnInit(): void {
    this._kadaService.getMarqueListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.marques = v.results;
    })
  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        const data = { ...this.form.value };
        this._kadaService.createModel(data)
          .subscribe({
            next: (response) => {
              this.dialogRef.close(true);
              this._toastr.success("Modele ajouté avec succès!");
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
        this._kadaService.updateModel({ ...this.form.value,id:this.data?.id })
          .subscribe({
            next: () => {
              this.dialogRef.close(true);
              this._toastr.success("Modele modifié avec succès!");
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
