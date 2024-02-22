import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-batterie',
  templateUrl: './batterie.component.html',
})
export class BatterieComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.batterie
  }
}
