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

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.scss']
})
export class ListUsersComponent extends BaseTableComponent {
  displayedColumns = ['id', 'email', 'firstname', 'lastname'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _userService: UserService,
    protected override _cd: ChangeDetectorRef,
    protected override _formBuilder: FormBuilder,
    protected override _router: Router,
    private _dialog: MatDialog
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }

  override ngOnInit() {
    combineLatest([
      this.searchForm.get('firstName')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('firstName')!.value)
        ),
      this.searchForm.get('lastName')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('lastName')!.value)
        ),
      this.searchForm.get('identifiant')!.valueChanges
        .pipe(
          debounceTime(800),
          distinctUntilChanged(),
          startWith(this.searchForm.get('identifiant')!.value)
        ),
    ]).pipe(takeUntil(this.$ngOnDestroyed))
      .subscribe((
        [
          firstName,
          lastName,
          identifiant,
        ]) => {
        this.searchForm.patchValue({
          firstName,
          lastName,
          identifiant,
        }, { emitEvent: false });
        this.triggerSearch();
      });
  }

  protected _search(criteria: any): Observable<any> {
    return this._userService.getUserListPage(criteria);
  }


  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      firstName: null,
      lastName: null,
      identifiant: null,
    });
  }

  openDialog(action:string,row:any) {
    row['action']=action;
    row['title']=(action=='add'?'Ajout d\'un Utilisateur':`Modification de l'Utilisateur ${row.firstName} ${row.lastName}`);
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

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }
}