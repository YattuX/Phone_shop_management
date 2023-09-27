import { Component, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-product',
  templateUrl: './addProduct.html',
})
export class AddProduct {
  showSpinner: boolean = false;
  title: string = '';
  marque : any = [
    {
      id: 1,
      name : 'Telephone',
    },
    {
      id:2,
      name : 'Tablette',
    },
    {
      id:3,
      name : 'Ordinateur',
    },
  ]
  
constructor(){

    }
}
