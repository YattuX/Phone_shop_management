import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable, from, of } from 'rxjs';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { UserService } from 'src/app/shared/services/user.service';

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
    protected override _router: Router
  ) {
    super(_cd, _formBuilder, _router);
    this._createSearchForm();
  }


  override ngOnInit() {
    super.triggerSearch();
  }
  protected _search(criteria: any): Observable<any> {
    return this._userService.GetUserListPage()
  }


  protected override _createSearchForm() {
    this.searchForm = this._formBuilder.group({
      firstName: null,
      lastName: null,
    });
  }
}