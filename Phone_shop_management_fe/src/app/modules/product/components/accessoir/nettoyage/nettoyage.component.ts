import { Component } from '@angular/core';
import { Tabs } from '../accessoir.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-nettoyage',
  templateUrl: './nettoyage.component.html',
})
export class NettoyageComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.diluant
  }
}
