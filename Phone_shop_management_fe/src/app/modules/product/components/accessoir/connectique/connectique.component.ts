import { Component } from '@angular/core';
import { Tabs } from '../accessoir.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-connectique',
  templateUrl: './connectique.component.html',
})
export class ConnectiqueComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.conectiques
  }
}
