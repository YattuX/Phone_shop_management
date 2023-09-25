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
import { KadaService, MarqueDTO, ModelDTOSearchResult } from 'src/app/shared/services/kada.service';
import { SearchDTO } from 'src/app/shared/services/user.service';
import { ModeleDialog } from './modele.dialog';

@Component({
  selector: 'app-modele',
  templateUrl: './modele.component.html',
  styleUrls: ['./modele.component.scss']
})
export class ModeleComponent extends BaseTableComponent {
  displayedColumns = ['id', 'name', 'marque', 'action'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  marques: MarqueDTO[];

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

  override ngOnInit(): void {
    this._kadaService.getMarqueListPage(SearchDTO.fromJS({
      pageIndex: -1, filters: {}
    })).subscribe(v => {
      this.marques = v.results;
    });

    combineLatest([
      this.searchForm.get('name')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('name')?.value)),
      this.searchForm.get('marque')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('marque')?.value)),
    ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([name, marque]) => {
      this.searchForm.patchValue({
        name,
        marque
      }, { emitEvent: false });
      super.triggerSearch();
    });
  }

  protected override _search(criteria: any): Observable<ModelDTOSearchResult> {
    return this._kadaService.getModelListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      name: null,
      marque: null
    });
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }

  openDialog(action: string, row: any) {
    row['action'] = action;
    console.log(action)
    row['title'] = (action == 'add' ? 'Ajout d\'un Modèle' : `Modification du Modèle ${row.name}`);
    this._dialog.open(ModeleDialog, {
      data: row,
      disableClose: true,
      width: '900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.triggerSearch();
      }
    })
  }


  removeRows(row: MarqueDTO) {
    this._dialog.open(InfoDialog, {
      data: {
        title: `Supression du modèle ${row.name}`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer ce Modèle?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width: '900px'
    }).afterClosed().subscribe((res) => {
      if (res) {
        this._kadaService.deleteModel(row.id!)
          .subscribe({
            next: () => {
              this._toastr.success("Modèle supprimé avec succès!");
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
