import { ChangeDetectorRef, Component } from '@angular/core';
import { ArticleDTO, ArticleDTOSearchResult, KadaService } from 'src/app/shared/services/kada.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-telephone',
  templateUrl: './telephone.component.html',
})
export class TelephoneComponent extends BaseTableComponent {
  constructor(
    protected _kadaService: KadaService,
    protected override _cd: ChangeDetectorRef,
    protected override _formBuilder: FormBuilder,
    protected override  _router: Router,
    private _dialog: MatDialog,
    private _toastr: ToastrService,
  ){
    super(_cd, _formBuilder, _router);
  }

  protected override _search(criteria: any): Observable<ArticleDTOSearchResult> {
    criteria.filters = {typeArticle : "telephone"}
    return this._kadaService.getArticleListPage(criteria);
  }

}
