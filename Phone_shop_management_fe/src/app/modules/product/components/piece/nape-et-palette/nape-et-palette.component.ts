import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';

@Component({
  selector: 'app-nape-et-palette',
  templateUrl: './nape-et-palette.component.html',
})
export class NapeEtPaletteComponent {
  navs = Tabs;
}
