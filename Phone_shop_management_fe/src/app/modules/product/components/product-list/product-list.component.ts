import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent {
  title: string = 'Liste de produits'
  constructor(
    private _activatedRoute : ActivatedRoute
  ){
  }

  ngOnInit(): void {
    // console.log(this._activatedRoute.snapshot.routeConfig?.data?.['title'])
    
  }

}
