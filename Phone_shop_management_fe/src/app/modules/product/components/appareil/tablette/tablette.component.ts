import { Component } from '@angular/core';
import { Tabs } from '../product-list.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-tablette',
  templateUrl: './tablette.component.html',
})
export class TabletteComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.tablette
  }

}
