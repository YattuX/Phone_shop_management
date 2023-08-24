import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { InfoDialog } from '../dialogs/info/info.dialog';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  constructor(
    private _dialog:MatDialog
  ) {}
  openDialog() {
    this._dialog.open(InfoDialog,{
      data:{
        title:"Dignissimos aspernatur minus ipsum magni praesentium",
        message:`Lorem ipsum dolor sit amet consectetur, adipisicing elit. Repudiandae illum incidunt tempore perferendis enim recusandae
        assumenda omnis vero? Labore suscipit ad rerum maxime harum. Dignissimos aspernatur minus ipsum magni praesentium.
        Fuga itaque voluptatum veniam voluptate optio, et dolores necessitatibus exercitationem impedit dolorem corporis non
        perferendis delectus libero tenetur qui porro! Quisquam tempora eum molestiae modi ipsum possimus nesciunt fugit
        voluptas?`,
        type:'warn',
        
      }
    })
  }
}
