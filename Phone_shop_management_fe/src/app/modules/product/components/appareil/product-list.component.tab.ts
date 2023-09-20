import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductDialog } from '../product.dialog';
import { UiPath } from 'src/app/modules/ui-path';
import { Subscription } from 'rxjs';

export const Tabs = [
  { 
    routerLink: '/' + UiPath.products.appareil.telephone, 
    label: 'Liste des téléphones' 
  },
  { 
    routerLink: '/' + UiPath.products.appareil.tablette, 
    label: 'Liste des Tablettes' 
  },
  { 
    routerLink: '/' + UiPath.products.appareil.ordinateur, 
    label: 'Liste des ordinateurs' 
  }
];

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.tab.html',
})
export class ProductListComponent {
  navs2 = Tabs;
  title: string;
  routerEventSubscription: Subscription;
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _dialog: MatDialog,
    private router: Router,
  ) {
    this.title = 'Liste des articles'
  }

  ngOnInit(): void {
    this.routerEventSubscription =  this.router.events.subscribe((res) => {
      let selectedTab = this.navs2.find(tab => this.router.url.endsWith(tab.routerLink));
      if (selectedTab) {
       this.title = 'Article - ' + selectedTab.label;
      }
     });
  }

  addArticle() {
    this._dialog.open(ProductDialog, {
      width: '900px'
    })
  }

}
