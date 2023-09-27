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
import { KadaService, MarqueDTO, MarqueDTOSearchResult, TypeArticleDTO } from 'src/app/shared/services/kada.service';
import { MarqueDialog } from './marque.dialog';
import { SearchDTO } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-marque',
  templateUrl: './marque.component.html',
  styleUrls: ['./marque.component.scss']
})
export class MarqueComponent extends BaseTableComponent{
  displayedColumns = ['id', 'name','typeArticle','action'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  typeArticle:TypeArticleDTO[];
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
    this._kadaService.getTypeArticleListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.typeArticle = v.results;
    });

    combineLatest([
      this.searchForm.get('name')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('name')?.value)),
      this.searchForm.get('typeArticle')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('typeArticle')?.value)),
     ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([name,typeArticle]) => {
      this.searchForm.patchValue({
        name,
        typeArticle
      }, { emitEvent: false });
      super.triggerSearch();
    });
  }

  protected override _search(criteria: any): Observable<MarqueDTOSearchResult> {
    return this._kadaService.getMarqueListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      name: null,
      typeArticle:null
    });
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }

  openDialog(action: string, row: any) {
    row['action'] = action;
    row['title'] = (action == 'add' ? 'Ajout d\'une Marque' : `Modification de la Marque ${row.name}`);
    this._dialog.open(MarqueDialog, {
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
        title: `Supression de la marque ${row.name}`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer cette Marque?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width: '900px'
    }).afterClosed().subscribe((res) => {
      if (res) {
        this._kadaService.deleteMarque(row.id!)
          .subscribe({
            next: () => {
              this._toastr.success("Marque supprimée avec succès!");
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
