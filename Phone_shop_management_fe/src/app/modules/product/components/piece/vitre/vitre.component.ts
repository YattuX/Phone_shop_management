import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';

@Component({
  selector: 'app-vitre',
  templateUrl: './vitre.component.html',
})
export class VitreComponent {
  navs = Tabs;
}
