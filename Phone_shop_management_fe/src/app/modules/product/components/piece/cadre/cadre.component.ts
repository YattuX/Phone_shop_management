import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-cadre',
  templateUrl: './cadre.component.html',
})
export class CadreComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.cadre
  }
}
