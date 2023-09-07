import { ChangeDetectorRef, Directive } from "@angular/core";
import { BaseReactiveComponent } from "./base-reactive.component";
import { FormBuilder, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { Observable, takeUntil } from "rxjs";

@Directive()
export abstract class BaseTableComponent extends BaseReactiveComponent {
    total!: number;
    pageSize: number = 10;
    pageOffset: number = 0;
    pageRows = [];
    searchForm!: FormGroup;
    defaultSearchFormValue = {};

    constructor(
        protected _cd: ChangeDetectorRef,
        protected _formBuilder: FormBuilder,
        protected _router: Router
    ) {
        super();
    }


    protected _createSearchForm() {
        this.searchForm = this._formBuilder.group({});
    }

    protected onChangePage(pageInfo: { pageSize?: number, pageOffset?: number }) {
        this.pageSize = pageInfo.pageSize as number;
        this.pageOffset = pageInfo.pageOffset as number;
        
        this.pageRows = [];
        const container = document.querySelector('#main');
        container?container.scrollTop = 0:null;

        let criteria = Object.assign({}, {filters:this.searchForm.value}, {
            pageSize: this.pageSize,
            pageIndex: this.pageOffset,
        }, this._sortBy());
        this._search(criteria).pipe(takeUntil(this.$ngOnDestroyed)).subscribe((data: any) => {
            this.total = data['totalCount'];
            this.pageRows = data["results"];
            this.pageOffset = data["page"];
            this._cd.markForCheck();
        });
    }


    ngOnInit():void {
        let criteria = Object.assign({},{
            pageSize: this.pageSize,
            pageOffset: this.pageOffset,
        }, this._sortBy());

        this.pageSize = criteria.pageSize;
        this.pageOffset = criteria.pageOffset;
        this.searchForm.patchValue({ ...criteria }, { emitEvent: false });
        this._cd.markForCheck();
    }



    public triggerSearch() {
        this.onChangePage({ pageSize: this.pageSize, pageOffset: this.pageOffset });
    }

    public resetSearchForm() {
        this.searchForm.reset(this.defaultSearchFormValue, { emitEvent: false });
    }

    protected abstract _search(criteria: any): Observable<any>;

    protected _sortBy(): any {return null;}
}