import { Component, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogInfo } from './DialogInfo';

@Component({
  selector: 'app-info',
  templateUrl: './info.dialog.html',
  styleUrls: ['./info.dialog.scss']
})
export class InfoDialog {

  constructor(
    public dialogRef: MatDialogRef<InfoDialog>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: DialogInfo
  ) {}

  doAction(){
    this.dialogRef.close({response:true});
  }

  get colorthemeAdaptable():string{
    return this.data?.type === 'danger'||this.data?.type ==='warn' ?'warn':'primary';
  }
}


