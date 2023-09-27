import { Component, Optional, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { KadaService, ModelDTO, SearchDTO, TypeArticleDTO, TypeArticleDTOSearchResult } from 'src/app/shared/services/kada.service';

@Component({
  templateUrl: './caracteristique.dialog.html',
})
export class CaracteristiqueDialog implements OnInit {
  form: FormGroup;
  showSpinner: boolean = false;
  modeles: ModelDTO[];
  constructor(
    public dialogRef: MatDialogRef<CaracteristiqueDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
  ) {
    this.form = this._formBuilder.group({
      modelId: [data?.modelId, [Validators.required,]],
      hasStockage: [data.hasStockage ?? false],
      hasCouleur: [data.hasCouleur ?? false],
      hasNombreDeSim: [data.hasNombreDeSim ?? false],
      hasImei: [data.hasImei ?? false],
      hasParticularite: [data.hasParticularite ?? false],
      hasEtat: [data.hasEtat ?? false],
      hasProcesseurs: [data.hasProcesseurs ?? false],
      hasTailleEcran: [data.hasTailleEcran ?? false],
      hasRam: [data.hasRam ?? false],
      hasQualite: [data.hasQualite ?? false],
      hasType: [data.hasType ?? false],
      hasCapacite: [data.hasCapacite ?? false],
      hasCaracteristic: [data.hasCaracteristic ?? false],
      hasPuissance: [data.hasPuissance ?? false],
      hasCamera: [data.hasCamera ?? false],
    })
  }
  ngOnInit(): void {
    if (this.data?.action == 'add') {
      this._kadaService.getModelListPage(SearchDTO.fromJS({
        pageIndex: -1, filters: {notCaracteritique:'true'}
      })).subscribe(v => {
        this.modeles = v.results;
        if(this.modeles.length == 0){
          this.dialogRef.close();
          this._toastr.warning("Aucun modèle restant");
        }
      })
    } else if (this.data.action == 'edit') {
      this._kadaService.getModelListPage(SearchDTO.fromJS({
        pageIndex: -1, filters: {}
      })).subscribe(v => {
        this.modeles = v.results;
        this.form.controls['modelId'].disable();
      })
    }

  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        const data = { ...this.form.getRawValue() };
        this._kadaService.createCaracteristique(data)
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
        this._kadaService.updateCaracteristique({ ...this.form.getRawValue(), id: this.data?.id })
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
