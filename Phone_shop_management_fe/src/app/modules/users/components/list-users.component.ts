import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable, combineLatest, debounceTime, distinctUntilChanged, from, of, startWith, takeUntil } from 'rxjs';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { UserService } from 'src/app/shared/services/user.service';
import { AddUserDialog } from './user.dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.scss']
})
export class ListUsersComponent extends BaseTableComponent {
  displayedColumns = ['id', 'lastname','firstname','email','phone','role','action'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();

  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _userService: UserService,
    protected override _cd: ChangeDetectorRef,
    protected override _formBuilder: FormBuilder,
    protected override _router: Router,
    private _dialog: MatDialog,
    private _toastr:ToastrService,
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }

  override ngOnInit() {
    combineLatest([
      this.searchForm.get('email')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('email')!.value)
        ),
      this.searchForm.get('firstname')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('firstname')!.value)
        ),
      this.searchForm.get('lastname')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('lastname')!.value)
        ),
      this.searchForm.get('phoneNumber')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('phoneNumber')!.value)
        ),
    ]).pipe(takeUntil(this.$ngOnDestroyed))
      .subscribe((
        [
          email,
          firstname,
          lastname,
          phoneNumber
        ]) => {
        this.searchForm.patchValue({
          email,
          firstname,
          lastname,
          phoneNumber
        }, { emitEvent: false });
        this.triggerSearch();
      });
  }

  protected _search(criteria: any): Observable<any> {
    return this._userService.getUserListPage(criteria);
  }


  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      email: null,
      firstname: null,
      lastname: null,
      phoneNumber:null
    });
  }

  openDialog(action:string,row:any) {
    row['action']=action;
    row['title']=(action=='add'?'Ajout d\'un Utilisateur':`Modification de l'Utilisateur ${row.firstname} ${row.lastname}`);
    this._dialog.open(AddUserDialog, {
      data: row,
      disableClose: true,
      width:'900px'
    }).afterClosed().subscribe(response => {
      if (response) {
        this.triggerSearch();
      }
    })
  }

  removeRows(row: any) {
    this._dialog.open(InfoDialog, {
      data: {
        title: `Supression de l'Utilisateur ${row.firstname} ${row.lastname}`,
        type: "warn",
        message: "Êtes-vous sûr de vouloir supprimer cet utilisateur?",
        cancelAction: "Non",
        valideAction: "Oui, je suis sûr",
      },
      width:'800px'
    }).afterClosed().subscribe((res)=>{
      if(res){
        this._userService.deleteUser(row.id!)
        .subscribe({
          next:()=>{
            this._toastr.success("Client supprimé avec succès!");
            this.triggerSearch();
          },
          error:(err)=>{
            this._toastr.error(`Erreur! Veuillez réessayer!`)
          }
        })
      }
    })
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }
}