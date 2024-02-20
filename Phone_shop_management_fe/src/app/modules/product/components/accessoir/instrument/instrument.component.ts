import { Component } from '@angular/core';
import { Tabs } from '../accessoir.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-instrument',
  templateUrl: './instrument.component.html',
})
export class InstrumentComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.instrument
  }
}
