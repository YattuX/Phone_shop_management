import { Component } from '@angular/core';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-anti-casse',
  templateUrl: './anti-casse.component.html',
})
export class AntiCasseComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.antiCasse
  }
}
