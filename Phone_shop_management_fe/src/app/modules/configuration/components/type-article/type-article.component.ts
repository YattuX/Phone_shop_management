import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith, takeUntil } from 'rxjs';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { KadaService, TypeArticleDTO, TypeArticleDTOSearchResult } from 'src/app/shared/services/kada.service';
import { TypeArticleDialog } from './type-article.dialog';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';

@Component({
  selector: 'app-type-article',
  templateUrl: './type-article.component.html',
  styleUrls: ['./type-article.component.scss']
})
export class TypeArticleComponent extends BaseTableComponent {

  displayedColumns = ['id', 'name','action'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  title: string = 'Liste des Type Articles';

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
    combineLatest([
      this.searchForm.get('name')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('name')?.value)),
     ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([name,]) => {
      this.searchForm.patchValue({
        name,
      }, { emitEvent: false });
      super.triggerSearch();
    });
  }

  protected override _search(criteria: any): Observable<TypeArticleDTOSearchResult> {
    return this._kadaService.getTypeArticleListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      name: null,
    });
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }

  openDialog(action: string, row: any) {
    row['action'] = action;
    console.log(action)
    row['title'] = (action == 'add' ? 'Ajout d\'un Type d\'article' : `Modification du Type d'article ${row.name}`);
    this._dialog.open(TypeArticleDialog, {
      data: row,
      disableClose: true,
      width: '900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.triggerSearch();
      }
    })
  }


  removeRows(row: TypeArticleDTO) {
    this._dialog.open(InfoDialog, {
      data: {
        title: `Supression du Client ${row.name}`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer ce Type d'article?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width: '900px'
    }).afterClosed().subscribe((res) => {
      if (res) {
        this._kadaService.deleteTypeArticle(row.id!)
          .subscribe({
            next: () => {
              this._toastr.success("Type d'article supprimé avec succès!");
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
