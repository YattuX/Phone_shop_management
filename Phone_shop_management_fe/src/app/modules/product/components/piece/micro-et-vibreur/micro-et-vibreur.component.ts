import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-micro-et-vibreur',
  templateUrl: './micro-et-vibreur.component.html',
})
export class MicroEtVibreurComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.microEtVibreur
  }
}
