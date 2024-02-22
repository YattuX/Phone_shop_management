import { Component } from '@angular/core';
import { Tabs } from '../piece.component.tab';
import { TypeArticleName } from 'src/app/core/models/Utils';

@Component({
  selector: 'app-camera',
  templateUrl: './camera.component.html',
})
export class CameraComponent {
  typeArticle : string = "";

  constructor()
  {
    this.typeArticle = TypeArticleName.camera
  }
}
