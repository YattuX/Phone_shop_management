import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith, takeUntil } from 'rxjs';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { CouleurDTO, CouleurDTOSearchResult, KadaService } from 'src/app/shared/services/kada.service';
import { CouleurDialog } from './couleur.dialog';

@Component({
  selector: 'app-couleur',
  templateUrl: './couleur.component.html',
  styleUrls: ['./couleur.component.scss']
})
export class CouleurComponent extends BaseTableComponent{
  displayedColumns = ['id', 'name','code','action'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();

  constructor(
    protected _kadaService: KadaService,
    protected override _cd: ChangeDetectorRef,
    protected override _formBuilder: FormBuilder,
    protected override  _router: Router,
    private _dialog: MatDialog,
    private _toastr: ToastrService,
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }

  override ngOnInit(){
    combineLatest([
      this.searchForm.get('name')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('name')?.value)),
      this.searchForm.get('code')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('code')?.value)),
     ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([name,code]) => {
      this.searchForm.patchValue({
        name,
        code
      }, { emitEvent: false });
      super.triggerSearch();
    });
  }

  protected override _search(criteria: any): Observable<CouleurDTOSearchResult> {
    return this._kadaService.getCouleurListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      name: null,
      code:null
    });
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }
  
  openDialog(action: string, row: any) {
    row['action'] = action;
    row['title'] = (action == 'add' ? 'Ajout d\'une Couleur' : `Modification de la Couleur ${row.name}`);
    this._dialog.open(CouleurDialog, {
      data: row,
      disableClose: true,
      width: '900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.triggerSearch();
      }
    })
  }


  removeRows(row: CouleurDTO) {
    this._dialog.open(InfoDialog, {
      data: {
        title: `Supression de la Couleur ${row.name}`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer cette Couleur?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width: '900px'
    }).afterClosed().subscribe((res) => {
      if (res) {
        this._kadaService.deleteCouleur(row.id!)
          .subscribe({
            next: () => {
              this._toastr.success("Couleur supprimée avec succès!");
              this.triggerSearch();
            },
            error: (err) => {
              this._toastr.error(`Erreur! Veuillez réessayer!\n ${err?.title}`)
            }
          })
      }
    })
  }

}
