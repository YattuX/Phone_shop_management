import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, map, startWith, takeUntil } from 'rxjs';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { CaracteristiqueDTO, CaracteristiqueDTOSearchResult, KadaService, ModelDTO, ModelDTOSearchResult } from 'src/app/shared/services/kada.service';
import { SearchDTO } from 'src/app/shared/services/user.service';
import { CaracteristiqueDialog } from './caracteristique.dialog';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';

@Component({
  selector: 'app-caracteristique',
  templateUrl: './caracteristique.component.html',
  styleUrls: ['./caracteristique.component.scss']
})
export class CaracteristiqueComponent extends BaseTableComponent {
  displayedColumns = ['id', 'modele', 'action'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  modeles: ModelDTO[];

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
    this._kadaService.getModelListPage(SearchDTO.fromJS({
      pageIndex: -1, filters: {}
    })).subscribe(v => {
      this.modeles = v.results;
    });

    combineLatest([
      // this.searchForm.get('name')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('name')?.value)),
      this.searchForm.get('model')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('model')?.value)),
      this.searchForm.get('hasStockage')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasStockage')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasCouleur')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasCouleur')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasNombreDeSim')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasNombreDeSim')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasImei')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasImei')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasParticularite')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasParticularite')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasEtat')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasEtat')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasProcesseurs')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasProcesseurs')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasTailleEcran')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasTailleEcran')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasRam')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasRam')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasQualite')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasQualite')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasType')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasType')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasCapacite')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasCapacite')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasCaracteristic')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasCaracteristic')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasPuissance')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasPuissance')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasPosition')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasPosition')?.value),map((value) => (value ? `${value}` : null))),
      this.searchForm.get('hasDescription')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('hasDescription')?.value),map((value) => (value ? `${value}` : null))),
    ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([model,hasStockage,hasCouleur,hasNombreDeSim,hasImei,hasParticularite,hasEtat,hasProcesseurs,hasTailleEcran,hasRam,hasQualite,hasType,hasCapacite,hasCaracteristic,hasPuissance,hasPosition,hasDescription]) => {
      this.searchForm.patchValue({
        model,
        hasStockage,hasCouleur,hasNombreDeSim,hasImei,hasParticularite,
        hasEtat,hasProcesseurs,hasTailleEcran,hasRam,hasQualite,hasType,
        hasCapacite,hasCaracteristic,hasPuissance,hasPosition,hasDescription
      }, { emitEvent: false });
      super.triggerSearch();
    });
  }

  protected override _search(criteria: any): Observable<CaracteristiqueDTOSearchResult> {
    return this._kadaService.getCaracteristiqueListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      model: null,
      hasStockage: null,
      hasCouleur: null,
      hasNombreDeSim: null,
      hasImei: null,
      hasParticularite: null,
      hasEtat: null,
      hasProcesseurs: null,
      hasTailleEcran: null,
      hasRam: null,
      hasQualite: null,
      hasType: null,
      hasCapacite: null,
      hasCaracteristic: null,
      hasPuissance: null,
      hasPosition: null,
      hasDescription: null,
    });
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }

  openDialog(action: string, row: any) {
    row['action'] = action;
    row['title'] = (action == 'add' ? 'Ajout des Caracteristiques d\'un modèle' : `Caracteristiques du modèle ${row.modelName}`);
    this._dialog.open(CaracteristiqueDialog, {
      data: row,
      disableClose: true,
      width: '900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.triggerSearch();
      }
    })
  }


  removeRows(row: CaracteristiqueDTO) {
    this._dialog.open(InfoDialog, {
      data: {
        title: `Supression de la caracteristique`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer cette caracteristique?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width: '900px'
    }).afterClosed().subscribe((res) => {
      if (res) {
        this._kadaService.deleteCaracteristique(row.id!)
          .subscribe({
            next: () => {
              this._toastr.success("caracteristique supprimée avec succès!");
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
