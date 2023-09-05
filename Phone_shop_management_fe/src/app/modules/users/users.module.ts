import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListUsersComponent } from './components/list-users/list-users.component';
import { UsersRoutingModule } from './users-routing.module';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableResponsiveModule } from 'src/app/shared/global/mat-table-responsive/mat-table-responsive.module';
import { DataPropertyGetterPipe } from 'src/app/shared/components/pipes/data-property-getter.pipe';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { SharedModule } from 'src/app/shared/shared.module';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { AddUserDialog } from './components/add-user/add-user.component';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({

  imports: [
    CommonModule,
    UsersRoutingModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableResponsiveModule,
    MatIconModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    SharedModule,
    DragDropModule,
    MatDialogModule
  ]
  ,
  declarations: [
    ListUsersComponent,
    DataPropertyGetterPipe,
    AddUserDialog,
  ],
})
export class UsersModule { }
