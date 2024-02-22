import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-nape-et-palette',
  templateUrl: './nape-et-palette.component.html',
})
export class NapeEtPaletteComponent {
  navs = Tabs;
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.napeEtPlaquette
  }
}
