import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith,takeUntil } from 'rxjs';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { FournisseurDto, KadaService } from 'src/app/shared/services/kada.service';
import { ProviderDialog } from './provider.dialog';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-provider',
  templateUrl: './list-provider.component.html',
})
export class ListProviderComponent extends BaseTableComponent implements OnInit {
  displayedColumns = ['identifiant', 'lastName', 'name', 'email', 'whatsappNumber', 'action'];

  dataSource: MatTableDataSource<any> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    protected override _cd: ChangeDetectorRef,
    protected override _formBuilder: FormBuilder,
    protected override _router: Router,
    private _dialog: MatDialog,
    private _kadaService: KadaService,
    private _toastr:ToastrService,
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }


  override ngOnInit() {
    combineLatest([
      this.searchForm.get('lastName')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('lastName')!.value)
        ),
      this.searchForm.get('name')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('name')!.value)
        ),
      this.searchForm.get('email')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('email')!.value)
        ),
      this.searchForm.get('whatsappNumber')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('whatsappNumber')!.value)
        ),
      this.searchForm.get('identifiant')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('identifiant')!.value)
        ),
    ]).pipe(takeUntil(this.$ngOnDestroyed))
      .subscribe((
        [
          lastName,
          name,
          email,
          whatsappNumber,
          identifiant
        ]) => {
        this.searchForm.patchValue({
          lastName,
          name,
          email,
          whatsappNumber,
          identifiant
        }, { emitEvent: false });
        this.triggerSearch();
      });
  }
  protected _search(criteria: any): Observable<any> {
    return this._kadaService.getFournisseurListPage(criteria)
  }


  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      lastName: null,
      name: null,
      email: null,
      whatsappNumber: null,
      identifiant: null
    });
  }

  openDialog(action:string,row:any) {
    row['action']=action;
    row['title']=(action=='add'?'Ajout d\'un fournisseur':`Modification du fournisseur ${row.name} ${row.lastName}`);
    this._dialog.open(ProviderDialog, {
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

  removeRows(row: FournisseurDto) {
    this._dialog.open(InfoDialog, {
      data: {
        title: `Supression du Fournisseur ${row.name} ${row.lastName}`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer ce fournisseur?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width:'900px'
    }).afterClosed().subscribe((res)=>{
      if(res){
        this._kadaService.deleteFournisseur(row.id!)
        .subscribe({
          next:()=>{
            this._toastr.success("Fournisseur supprimé avec succès!");
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
