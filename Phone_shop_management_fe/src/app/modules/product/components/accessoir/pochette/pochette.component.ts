import { Component } from '@angular/core';
import { Tabs } from '../accessoir.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-pochette',
  templateUrl: './pochette.component.html',
})
export class PochetteComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.pochette
  }
}
