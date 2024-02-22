import { Component } from '@angular/core';
import { Tabs } from '../product-list.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-ordinateur',
  templateUrl: './ordinateur.component.html',
})
export class OrdinateurComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.ordinateur
  }
}
