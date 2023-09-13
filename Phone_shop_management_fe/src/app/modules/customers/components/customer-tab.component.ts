import { Component } from "@angular/core";
import { customerRoutes } from "../customer-routing.module";
import { CustomerDialog } from "./customer.dialog";
import { MatDialog } from "@angular/material/dialog";
import { Router } from "@angular/router";

@Component({
    selector: 'app-customer-tab',
    templateUrl: './customer-tab.component.html',
})
export class CustomerTabComponent {
    tabRoutes = customerRoutes;
    activeLink = '';
    constructor(
        private _dialog: MatDialog,
        private _router: Router,
    ) { 
        this.activeLink = location.pathname.split('/')[2];        
    }
    openDialog(action: string, row: any) {
        row['action'] = action;
        row['title'] = (action == 'add' ? 'Ajout d\'un client' : `Modification du client ${row.name} ${row.lastName}`);
        this._dialog.open(CustomerDialog, {
            data: row,
            disableClose: true,
            width: '900px'
        }).afterClosed().subscribe(response => {            
            if (response) {
                this._router.navigateByUrl('/customer');
            }
        })
    }
}