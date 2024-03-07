import { ChangeDetectorRef, Component, EventEmitter, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { StockDialog } from '../stock-dialog/stock.dialog';

@Component({
  selector: 'app-stock-tab',
  templateUrl: './stock-tab.component.html',
})
export class StockTabComponent {
  dialogOpen : boolean = false
  title: string
  change: EventEmitter<boolean> = new EventEmitter();

  /**
   *
   */
  constructor(
    protected _cd: ChangeDetectorRef,
    private _dialog: MatDialog,
  ) {
    this.title = "Gestion de stock"
  }

 
  closeDialog(event : any){
    console.log(event)
    this.dialogOpen = event
    this._cd.markForCheck()
  }

  openDialog(action: string, row: any) {
    row['action'] = action;
    row['title'] = (action == 'add' ? 'Ajout d\'un stock' : `Modification d'un stock`);
    this._dialog.open(StockDialog, {
      data: row,
      disableClose: true,
      width: '900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.change.emit(true)
      }
    })
  }

}
