import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ProductDialog } from './product.dialog';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent {
  title: string = 'Liste des articles'
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _dialog: MatDialog,
  ) {
  }

  ngOnInit(): void {

  }

  addArticle() {
    this._dialog.open(ProductDialog, {
      width: '900px'
    })
  }

}
