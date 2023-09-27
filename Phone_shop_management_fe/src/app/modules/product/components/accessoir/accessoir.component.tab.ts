import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UiPath } from 'src/app/modules/ui-path';

export const Tabs = [
  {
    routerLink: '/' + UiPath.products.accessoir.anti_cass,
    label: 'Liste des anti-casse'
  },
  {
    routerLink: '/' + UiPath.products.accessoir.appreil_accessoir,
    label: 'Liste des appareils accessoir'
  },
  {
    routerLink: '/' + UiPath.products.accessoir.connectique,
    label: 'Liste des connectiques'
  },
  {
    routerLink: '/' + UiPath.products.accessoir.instrument,
    label: 'Liste des instruemesnt'
  },
  {
    routerLink: '/' + UiPath.products.accessoir.netoyage,
    label: 'Liste des nettoyant'
  },
  {
    routerLink: '/' + UiPath.products.accessoir.pochette,
    label: 'Liste des pochettes'
  }
];

@Component({
  selector: 'app-accessoir',
  templateUrl: './accessoir.component.tab.html',
})
export class AccessoirComponent {
  navs3 = Tabs;
  title: string;
  routerEventSubscription: Subscription;

  constructor(
    private _dialog: MatDialog,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.routerEventSubscription = this.router.events.subscribe((res) => {
      let selectedTab = this.navs3.find(tab => this.router.url.endsWith(tab.routerLink));
      if (selectedTab) {
        this.title = 'Article - ' + selectedTab.label;
      }
    });
  }

  addArticle() {
    this.router.navigateByUrl(UiPath.products.addProduct.add)
  }

}
