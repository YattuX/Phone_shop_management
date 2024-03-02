import { moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, startWith, takeUntil } from 'rxjs';
import { TECHNICIEN_ROLE, etatsReparationValues, statutPaiementValues } from 'src/app/core/models/Utils';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { ArticleDTO, ClientDto, EtatDTO, KadaService } from 'src/app/shared/services/kada.service';
import { SearchDTO, UserModel, UserService } from 'src/app/shared/services/user.service';
import { AddReparationDialog } from '../add-reparation/add-reparation.component';

@Component({
  selector: 'app-list-repair',
  templateUrl: './list-repair.component.html',
  styleUrls:['./list-repair.component.scss'],
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class ListRepairComponent extends BaseTableComponent {
  displayedColumns: string[] = ["clientId", "articleId", "description", "dateDepot", "dateLivraison", "coutReparation", "reparateurEnCharge","etatReparation", "statutPaiement",  "action"];
  title = "Reparation";

  userLists: Array<any>;
  clientsList: Array<any>;
  articlesList: Array<ArticleDTO>;
  etatsReparationList = etatsReparationValues;
  statutPaiemenetList = statutPaiementValues;

  constructor(
    protected override _cd: ChangeDetectorRef,
    protected override _formBuilder: FormBuilder,
    protected override _router: Router,
    private _dialog: MatDialog,
    private _kadaService: KadaService,
    private _toastr: ToastrService,
    private _userService: UserService,
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }

  override ngOnInit(): void {

    this._userService.getUserListPage(SearchDTO.fromJS({
      filters: {
        role: TECHNICIEN_ROLE.Name
      }, pageIndex: -1
    })).subscribe(res => {
      this.userLists = res.results.map(v => ({ ...v, fullName: `${v.firstname} ${v.lastname}` }));
      this._cd.markForCheck();
    });

    this._kadaService.getClientListPage(SearchDTO.fromJS({
      filters: {}, pageIndex: -1
    })).subscribe(res => {
      this.clientsList = res.results.map(v => ({ ...v, fullName: `${v.name} ${v.lastName}` }));
      this._cd.markForCheck();
    });

    this._kadaService.getArticleListPage(SearchDTO.fromJS({
      filters: {}, pageIndex: -1
    })).subscribe(res => {
      this.articlesList = res.results;
      this._cd.markForCheck();
    });

    combineLatest([
      this.searchForm.get('clientId')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('clientId')!.value)
        ),
      this.searchForm.get('articleId')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('articleId')!.value)
        ),
      this.searchForm.get('description')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('description')!.value)
        ),
      this.searchForm.get('dateDepot')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('dateDepot')!.value)
        ),
      this.searchForm.get('dateLivraison')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('dateLivraison')!.value)
        ),
      this.searchForm.get('etatReparation')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('etatReparation')!.value?.toString())
        ),
      this.searchForm.get('statutPaiement')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('statutPaiement')!.value?.toString())
        ),
      this.searchForm.get('coutReparation')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('coutReparation')!.value)
        ),
      this.searchForm.get('reparateurEnCharge')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('reparateurEnCharge')!.value)
        ),
    ]).pipe(takeUntil(this.$ngOnDestroyed))
      .subscribe((
        [
          clientId,
          articleId,
          description,
          dateDepot,
          dateLivraison,
          etatReparation,
          statutPaiement,
          coutReparation,
          reparateurEnCharge
        ]) => {
        this.searchForm.patchValue({
          clientId,
          articleId,
          description,
          dateDepot,
          dateLivraison,
          etatReparation: etatReparation === "" ? null : etatReparation?.toString(),
          statutPaiement: statutPaiement === "" ? null : statutPaiement?.toString(),
          coutReparation,
          reparateurEnCharge
        }, { emitEvent: false });
        this.triggerSearch();
      });
  }

  protected override _search(criteria: any): Observable<any> {
    return this._kadaService.getReparationListPage(criteria);
  }

  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      clientId: null,
      articleId: null,
      description: null,
      dateDepot: null,
      dateLivraison: null,
      etatReparation: null,
      statutPaiement: null,
      coutReparation: null,
      reparateurEnCharge: null,
    });
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }

  getEtatReparationTitle = (etat:number) =>{
    return etatsReparationValues.find(v => v.id == etat)?.name;
  }

  getStatutPaiementTitle = (statut:number) =>{
    return statutPaiementValues.find(v => v.id === statut)?.name;
  }

  getReparateur(id: string) {
    if (!(this.userLists && this.userLists.length > 0)) return null;
    const user = this.userLists.find(v => v.id === id);
    return `${user?.firstname} ${user?.lastname}`;
  }

  openDialog(action: string, row: {}) {
    this._dialog.open(AddReparationDialog,{
      data:{
        action,
        row
      }
    }).afterClosed().subscribe(res =>{
      if(res){
        this.triggerSearch();
      }
    })
  }

  blured(event){
    console.log(event);
    
  }

}
