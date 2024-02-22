import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-haut-parleur',
  templateUrl: './haut-parleur.component.html',
})
export class HautParleurComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.hautParleur
  }
}
