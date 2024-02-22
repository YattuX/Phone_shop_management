import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-vitre',
  templateUrl: './vitre.component.html',
})
export class VitreComponent {
  navs = Tabs;
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.vitre
  }
}
