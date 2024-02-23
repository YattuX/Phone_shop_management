import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UiPath } from 'src/app/modules/ui-path';

export const Tabs = [
  {
    routerLink: '/' + UiPath.products.materiel.appreil_accessoir,
    label: 'Liste des accessoires'
  },
];

@Component({
  selector: 'app-material',
  templateUrl: './material.tab.component.html'
})
export class MaterialTabComponent {
  navs2 = Tabs;
  title: string;
  routerEventSubscription: Subscription;
  
  constructor(
    private router: Router,
  ) {
    this.title = 'Liste des articles'
  }

  ngOnInit(): void {
    this.routerEventSubscription = this.router.events.subscribe((res) => {
      let selectedTab = this.navs2.find(tab => this.router.url.endsWith(tab.routerLink));
      if (selectedTab) {
        this.title = 'Article - ' + selectedTab.label;
      }
    });
  }

  addArticle() {
    this.router.navigateByUrl(UiPath.products.addProduct.add)
  }
}
