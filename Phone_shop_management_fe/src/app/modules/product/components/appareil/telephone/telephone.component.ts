import { Component } from "@angular/core";
import { TypeArticleName } from "src/app/core/models/Utils";

@Component({
  selector: 'app-telephone',
  templateUrl: './telephone.component.html',
})
export class TelephoneComponent  {
  typeArticle : string = ""

  constructor()
  {
    this.typeArticle = TypeArticleName.telephone
  }

}
