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
import { KadaService } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
})
export class ListCustomerComponent extends BaseTableComponent {
  displayedColumns = ['id','identifiant', 'firstname', 'lastname', 'telephone','whatsapp','adress' ];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  title: string = 'Liste des clients'
    
    constructor(
      protected _userService: UserService,
      protected _kadaService: KadaService,
      protected override _cd: ChangeDetectorRef,
      protected override _formBuilder: FormBuilder,
      protected override  _router: Router,
      private _dialog: MatDialog
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

    openDialog() {
      this._dialog.open(CustomerDialog, {
        width:"900px",
        data: {},
      })
    }

    drop(event: any) {
      moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
    }
}
