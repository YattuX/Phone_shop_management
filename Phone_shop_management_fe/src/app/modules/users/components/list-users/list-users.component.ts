import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable, from, of } from 'rxjs';
import { InfoDialog } from 'src/app/shared/components/dialogs/info/info.dialog';
import { BaseTableComponent } from 'src/app/shared/components/table/base-table.component';
import { UserService } from 'src/app/shared/services/user.service';
import { AddUserComponent } from '../add-user/add-user.component';

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
    private _dialog:MatDialog
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

  openDialog() {
    this._dialog.open(AddUserComponent,{
      data:{
        title:"Dignissimos aspernatur minus ipsum magni praesentium",
        message:`Lorem ipsum dolor sit amet consectetur, adipisicing elit. Repudiandae illum incidunt tempore perferendis enim recusandae
        assumenda omnis vero? Labore suscipit ad rerum maxime harum. Dignissimos aspernatur minus ipsum magni praesentium.
        Fuga itaque voluptatum veniam voluptate optio, et dolores necessitatibus exercitationem impedit dolorem corporis non
        perferendis delectus libero tenetur qui porro! Quisquam tempora eum molestiae modi ipsum possimus nesciunt fugit
        voluptas?`,
        type:'warn',
        
      },
    })
  }

  drop(event: any) {
    moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
  }
}