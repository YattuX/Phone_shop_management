import { Component } from '@angular/core';

@Component({
  selector: 'app-list-sale',
  templateUrl: './list-sale.component.html',
})
export class ListSaleComponent {
title: string;

  constructor(){
    this.title = "Vente"
  }
}
