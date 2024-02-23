import { Component } from '@angular/core';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-appareil-accessoir',
  templateUrl: './appareil-accessoir.component.html',
})
export class AppareilAccessoirComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.appareilAccessoir
  }
}
