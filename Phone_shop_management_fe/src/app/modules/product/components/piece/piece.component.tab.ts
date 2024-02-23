import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UiPath } from 'src/app/modules/ui-path';

export const Tabs = [
  {
    routerLink: '/' + UiPath.products.piece.batterie,
    label: 'Liste des batteries'
  },
  {
    routerLink: '/' + UiPath.products.piece.cadre,
    label: 'Liste des cadres'
  },
  {
    routerLink: '/' + UiPath.products.piece.camera,
    label: 'Liste des caméras'
  },
  {
    routerLink: '/' + UiPath.products.piece.ecran,
    label: 'Liste des écrans'
  },
  {
    routerLink: '/' + UiPath.products.piece.haut_parleur,
    label: 'Liste des hauts parleurs'
  },
  {
    routerLink: '/' + UiPath.products.piece.micro_et_vibreur,
    label: 'Liste des micros et vibreurs'
  },
  {
    routerLink: '/' + UiPath.products.piece.moteur,
    label: 'Liste des moteurs'
  },
  {
    routerLink: '/' + UiPath.products.piece.nape_et_palette,
    label: 'Liste des napes et palettes'
  },
  {
    routerLink: '/' + UiPath.products.piece.vitre,
    label: 'Liste des vitres'
  },
];

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.tab.html',
})
export class PieceComponent {
  navs1 = Tabs;
  title: string;
  routerEventSubscription: Subscription;
  constructor(
    private _dialog: MatDialog,
    private router: Router,
    private _location:Location
  ) {
    this.title = 'Liste des articles'
  }

  ngOnInit(): void {
    this.routerEventSubscription = this.router.events.subscribe((res) => {
      let selectedTab = this.navs1.find(tab => this.router.url.endsWith(tab.routerLink));
      if (selectedTab) {
        this.title = 'Article - ' + selectedTab.label;
      }
    });
}

  addArticle() {
    this.router.navigateByUrl(UiPath.products.addProduct.add)
  }

  goBack = ()=> this._location.back();

}
