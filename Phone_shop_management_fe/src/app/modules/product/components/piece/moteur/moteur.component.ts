import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-moteur',
  templateUrl: './moteur.component.html',
})
export class MoteurComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.moteur
  }
}
