import { Component, Inject, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ArticleDTO, KadaService, SearchDTO, StockDTO } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-stock-dialog',
  templateUrl: './stock.dialog.html',
})
export class StockDialog {
  form: FormGroup;
  showSpinner: boolean = false;
  articleList: ArticleDTO[]

  constructor( 
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
    public dialogRef: MatDialogRef<StockDialog>,
  ) {
    this.form = this._formBuilder.group({
      quantite: [data?.quantite, [Validators.required, Validators.max(100000), Validators.minLength(1)]],
      articleId: [data?.articleId, [Validators.required]],
      type: [`${data?.type}`, [Validators.required]]
    })
  }

  ngOnInit(): void {
      this._kadaService.getArticleListPage(SearchDTO.fromJS({
        pageIndex: -1,
        filters: {}
      }))
        .subscribe(res => {
          this.articleList = res.results
        })    
  }

  save() {
    if (this.form.valid) {
      var typeValue = parseInt(this.form.get('type').value)
      this.form.controls['type'].patchValue(typeValue)
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        const data = { ...this.form.value } as StockDTO;
        this._kadaService.addStock(data)
          .subscribe({
            next: (response) => {
              this.dialogRef.close(true);
              this._toastr.success("Stock ajouté avec succès!");
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
      else {
        var typeValue = parseInt(this.form.get('type').value)
        this.form.controls['type'].patchValue(typeValue)
        this._kadaService.updateStock({ ...this.form.value,id:this.data?.id })
          .subscribe({
            next: () => {
              this.dialogRef.close(true);
              this._toastr.success("Stock modifié avec succès!");
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
