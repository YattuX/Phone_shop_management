import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith, takeUntil } from 'rxjs';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { StockDialog } from '../stock-dialog/stock.dialog';
import { ArticleDTO, KadaService, SearchDTO } from 'src/app/shared/services/kada.service';

@Component({
  selector: 'app-etat-stock',
  templateUrl: './etat-stock.component.html',

})
export class EtatStockComponent extends BaseTableComponent {

  displayedColumns = ['id', 'articleName','quantiteRestante'];
  title: string;
  articleList: ArticleDTO[];
  override searchForm: FormGroup<any>;
  @Input() change: EventEmitter<boolean> = new EventEmitter(false);

  constructor(
    protected override _cd: ChangeDetectorRef,
    protected override  _formBuilder: FormBuilder,
    protected override _router: Router,
    private _dialog: MatDialog,
    private _toastr: ToastrService,
    private _activatedRoute: ActivatedRoute,
    private _kadaService: KadaService,
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }

  drop(event: any) {
    moveItemInArray([], event.previousIndex, event.currentIndex);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      articleId : null,
    });
  }

  protected override _search(criteria: any): Observable<any> {
    return this._kadaService.getStateStockListPage(criteria);
  }

   override ngOnInit(): void {
    this._kadaService.getArticleListPage(SearchDTO.fromJS({
      pageIndex: -1,
      filters: {}
    })).subscribe(res => {
      this.articleList = res.results
      console.log(this.articleList)
    })  
    this.change.subscribe(v=>{
      super.triggerSearch();
    }) 
  }

  ngAfterViewInit(): void {

    combineLatest([
      this.searchForm.get('articleId')?.valueChanges.pipe(debounceTime(800), distinctUntilChanged(), startWith(this.searchForm.get('articleId').value)),
    ]).pipe(takeUntil(this.$ngOnDestroyed)).subscribe(([articleId])=>{
      this.searchForm.patchValue({
        articleId,
      }, {emitEvent: false})
      this.triggerSearch()
    })
  }
}
