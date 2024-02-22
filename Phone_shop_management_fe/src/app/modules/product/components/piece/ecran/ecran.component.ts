import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-ecran',
  templateUrl: './ecran.component.html',
})
export class EcranComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.ecran
  }
}
