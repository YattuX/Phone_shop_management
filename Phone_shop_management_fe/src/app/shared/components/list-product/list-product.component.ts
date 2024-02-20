import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { ArticleDTOSearchResult, CouleurDTO, EtatDTO, ICaracteristiqueDTO, IModelDTO, KadaService, ModelDTO, ParticulariteDTO, SearchDTO, StockageDTO, TypeDTO } from 'src/app/shared/services/kada.service';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith, takeUntil } from 'rxjs';
import { TypeArticleName } from 'src/app/core/models/Utils';
import { moveItemInArray } from '@angular/cdk/drag-drop';


@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
})
export class ListProductComponent extends BaseTableComponent {
  @Input() typeArticle : string;
  displayedColumns: string[] = ["modele"];
  modeles: ModelDTO[];
  couleurs: CouleurDTO[];
  stockages: StockageDTO[];
  particularites: ParticulariteDTO[];
  etats: EtatDTO[];
  types: TypeDTO[];
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
    this._getModeles();
    this._getCouleurs();
    this._getStockages();
    this._getParticularites();
    this._getEtat();
    this._getType();
    combineLatest([
      this.searchForm.get('typeArticle')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('typeArticle')?.value)),
      this.searchForm.get('model')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('model')?.value)),
      this.searchForm.get('caracteristique')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('caracteristique')?.value)),
      this.searchForm.get('stockage')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('stockage')?.value)),
      this.searchForm.get('particularite')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('particularite')?.value)),
      this.searchForm.get('etat')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('etat')?.value)),
      this.searchForm.get('type')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('type')?.value)),
      this.searchForm.get('imei')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('imei')?.value)),
      this.searchForm.get('processeurs')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('processeurs')?.value)),
      this.searchForm.get('tailleEcran')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('tailleEcran')?.value)),
      this.searchForm.get('ram')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('ram')?.value)),
      this.searchForm.get('qualite')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('qualite')?.value)),
      this.searchForm.get('position')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('position')?.value)),
      this.searchForm.get('capacite')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('capacite')?.value)),
      this.searchForm.get('puissance')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('puissance')?.value)),
    ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([typeArticle, model, caracteristique, stockage, particularite, etat, type, imei, processeurs, tailleEcran, ram, qualite, position, capacite, puissance,]) => {
      this.searchForm.patchValue({
        typeArticle, model, caracteristique, stockage, particularite, etat, type, imei, processeurs, tailleEcran, ram, qualite, position, capacite, puissance,
      }, { emitEvent: false });
      super.triggerSearch();
    });

    this.loadingSubject.pipe(takeUntil(this.$ngOnDestroyed))
      .subscribe(isLoading => {
        if (!isLoading) {
          this.setdisplayedColumns = this.pageRows;
        }
      })
  }

  set setdisplayedColumns(pageRows: any[]) {
    let caracteristiques: ICaracteristiqueDTO[] = pageRows.map(v => v.caracteristiques);
    caracteristiques.forEach((caracteristique,) => {
      let names = Object.getOwnPropertyNames(caracteristique);
      names.forEach(column => {
        if (caracteristique[column] == true) {
          if (!this.displayedColumns.find(v => v === column)) {
            this.displayedColumns.push(column);
          }
        }
      });
      if (this.displayedColumns.includes("action")) {
        this.displayedColumns.splice(this.displayedColumns.indexOf("action"), 1);
      }
      this.displayedColumns.push("action");
    });
  }

  protected override _search(criteria: any): Observable<ArticleDTOSearchResult> {
    criteria.filters['typeArticle'] = this.typeArticle;
    return this._kadaService.getArticleListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      typeArticle: null,
      caracteristique: null,
      stockage: null,
      couleur: null,
      particularite: null,
      etat: null,
      type: null,
      imei: null,
      processeurs: null,
      tailleEcran: null,
      ram: null,
      qualite: null,
      position: null,
      capacite: null,
      puissance: null,
      // description: null,
      model: null,
    });
  }

  getChampCorrespondant(caracteristique: string) {
    switch (caracteristique) {
      case "hasStockage":
        return "stockage";
      case "hasCouleur":
        return "couleur";
      case "hasNombreDeSim":
        return "nombreDeSim";
      case "hasImei":
        return "imei";
      case "hasParticularite":
        return "particularite";
      case "hasEtat":
        return "etat";
      case "hasProcesseurs":
        return "processeurs";
      case "hasTailleEcran":
        return "tailleEcran";
      case "hasRam":
        return "ram";
      case "hasQualite":
        return "qualite";
      case "hasType":
        return "type";
      case "hasCapacite":
        return "capacite";
      case "hasCaracteristic":
        return "caracteristique";
      case "hasPuissance":
        return "puissance";
      case "hasPosition":
        return "position";
      case "hasDescription":
        return "description";
      default:
        return undefined;
    }
  }

  fieldActive(field: string) {
    return this.displayedColumns.includes(field);
  }

  private _getModeles() {
    this._kadaService.getModelListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: { typeArticle: TypeArticleName.telephone }
    }))
      .subscribe(res => {
        this.modeles = res.results
      })
  }

  private _getCouleurs() {
    this._kadaService.getCouleurListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    }))
      .subscribe(res => {
        this.couleurs = res.results
      })
  }

  private _getStockages() {
    this._kadaService.getStockageListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    }))
      .subscribe(res => {
        this.stockages = res.results
      })
  }

  private _getParticularites() {
    this._kadaService.getParticulariteListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    }))
      .subscribe(res => {
        this.particularites = res.results
      })
  }

  private _getEtat() {
    this._kadaService.getEtatListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    }))
      .subscribe(res => {
        this.etats = res.results
      })
  }

  private _getType() {
    this._kadaService.getTypeListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    }))
      .subscribe(res => {
        this.types = res.results
      })
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }
}
