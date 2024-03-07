import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith, takeUntil } from 'rxjs';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { StockDialog } from '../stock-dialog/stock.dialog';
import { ArticleDTO, KadaService, SearchDTO } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-list-stock',
  templateUrl: './list-stock.component.html',
})
export class ListStockComponent extends BaseTableComponent {
  displayedColumns = ['id', 'Produit','Quantité', 'Type de transaction','Date', 'Action'];
  title: string;
  articleList: ArticleDTO[];
  override searchForm: FormGroup<any>;
  @Input() change: EventEmitter<boolean> = new EventEmitter(false);
   
   constructor(
    protected override _cd: ChangeDetectorRef,
    protected override  _formBuilder: FormBuilder,
    protected override  _router: Router,
    private _dialog: MatDialog,
    private _toastr: ToastrService,
    private _activatedRoute: ActivatedRoute,
    private _kadaService: KadaService,
   ) {
      super(_cd, _formBuilder, _router);
      this._createSearchForm();
      this.title = "Historique de Stock";
   }

   drop(event: any) {
    moveItemInArray([], event.previousIndex, event.currentIndex);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      articleId : null,
      typeMouvement: null
    });
  }

   protected override _search(criteria: any): Observable<any> {
    return this._kadaService.getStockListPage(criteria)
  }
  
  override ngOnInit(): void {

    combineLatest([
      this.searchForm.get('articleId')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('articleId').value)),
      this.searchForm.get('typeMouvement')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('typeMouvement').value)),
    ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([articleId, typeMouvement])=>{
      this.searchForm.patchValue({
        articleId,
        typeMouvement
      }, {emitEvent: false})
      super.triggerSearch()
    })

    this._kadaService.getArticleListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    }))
      .subscribe(res => {
        this.articleList = res.results
      })   
    this.change.subscribe(v=>{
      super.triggerSearch();
    })
  }

  openDialog(action: string, row: any) {
    row['action'] = action;
    row['title'] = (action == 'add' ? 'Ajout d\'un stock' : `Modification d'un stock`);
    this._dialog.open(StockDialog, {
      data: row,
      disableClose: true,
      width: '900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.triggerSearch();
      }
    })
  }


}
