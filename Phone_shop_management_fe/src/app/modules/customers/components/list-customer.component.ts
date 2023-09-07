import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable, combineLatest, from, of, startWith } from 'rxjs';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { UserService } from 'src/app/shared/services/user.service';
import { CustomerDialog } from './customer.dialog';
import { ClientDto, KadaService } from 'src/app/shared/services/kada.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
})
export class ListCustomerComponent extends BaseTableComponent {
  displayedColumns = ['id','identifiant', 'firstname', 'lastname', 'telephone','whatsapp','adress','action' ];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  title: string = 'Liste des clients'
    
    constructor(
      protected _userService: UserService,
      protected _kadaService: KadaService,
      protected override _cd: ChangeDetectorRef,
      protected override _formBuilder: FormBuilder,
      protected override  _router: Router,
      private _dialog: MatDialog,
      private _toastr:ToastrService
    ) {
      super(_cd, _formBuilder, _router);
      this._createSearchForm();
    }

    protected override _search(criteria: any): Observable<any> {
      return this._kadaService.getClientListPage(criteria)
    }

    override ngOnInit(): void {
      combineLatest([
        this.searchForm.get('lastName')?.valueChanges.pipe(startWith(this.searchForm.get('lastName')?.value)),
        this.searchForm.get('name')?.valueChanges.pipe(startWith(this.searchForm.get('name')?.value)),
        this.searchForm.get('identifiant')?.valueChanges.pipe(startWith(this.searchForm.get('identifiant')?.value))
      ]).subscribe(([lastName, name, identifiant]) => {
        this.searchForm.patchValue({
          lastName,
          name,
          identifiant
        }, { emitEvent: false });
        super.triggerSearch();
      });

      super.triggerSearch();
    }

    protected override _createSearchForm() {
      this.searchForm = this._formBuilder.group({
        lastName: null,
        name: null,
        identifiant: null,
      });
    }

    openDialog(action:string,row:any) {
      row['action']=action;
      row['title']=(action=='add'?'Ajout d\'un client':`Modification du client ${row.name} ${row.lastName}`);
      this._dialog.open(CustomerDialog, {
        data: row,
        disableClose: true,
        width:'900px'
      }).afterClosed().subscribe(response => {
        if (response) {
          this.triggerSearch();
        }
      })
    }

    drop(event: any) {
      moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
    }

    removeRows(row: ClientDto) {
      this._dialog.open(InfoDialog, {
        data: {
          title: `Supression du Client ${row.name} ${row.lastName}`,
          type: "warn",
          message: "Êtes-vous sûr de vouloir supprimer ce Client?",
          cancelAction: "Non",
          valideAction: "Oui, je suis sûr",
        },
        width:'900px'
      }).afterClosed().subscribe((res)=>{
        if(res){
          this._kadaService.deleteClient(row.id!)
          .subscribe({
            next:()=>{
              this._toastr.success("Client supprimé avec succès!");
              this.triggerSearch();
            },
            error:(err)=>{
              this._toastr.error(`Erreur! Veuillez réessayer!\n ${err?.title}`)
            }
          })
        }
      })
    }
}
