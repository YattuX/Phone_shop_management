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

  openDialog(action:string,row:any){
    console.log({action,row});
    
  }
  removeRows(row:any){
    console.log({row});
    
  }

}
