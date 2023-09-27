import { Component, Optional, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { KadaService, SearchDTO, TypeArticleDTO, TypeArticleDTOSearchResult } from 'src/app/shared/services/kada.service';

@Component({
  templateUrl: './marque.dialog.html',
})
export class MarqueDialog implements OnInit {
  form: FormGroup;
  showSpinner: boolean = false;
  typeArticle:TypeArticleDTO[];
  constructor(
    public dialogRef: MatDialogRef<MarqueDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ) {
    this.form = this._formBuilder.group({
      name: [data?.name, [Validators.required, Validators.maxLength(50), Validators.minLength(2)]],
      typeArticleId: [data?.typeArticleId, [Validators.required,]],
    })
  }
  ngOnInit(): void {
    this._kadaService.getTypeArticleListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.typeArticle = v.results;
    })
  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        const data = { ...this.form.value };
        this._kadaService.createMarque(data)
          .subscribe({
            next: (response) => {
              this.dialogRef.close(true);
              this._toastr.success("Marque ajoutée avec succès!");
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
        this._kadaService.updateMarque({ ...this.form.value,id:this.data?.id })
          .subscribe({
            next: () => {
              this.dialogRef.close(true);
              this._toastr.success("Marque modifiée avec succès!");
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
