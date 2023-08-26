import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatTabsModule} from '@angular/material/tabs';
import {MatProgressBarModule} from '@angular/material/progress-bar';

import { Dashboard1Component } from './dashboard1/dashboard1.component';
import { Dashboard2Component } from './dashboard2/dashboard2.component';

import {
  TopCardComponent,
  SalesOverviewComponent,
  VisitorComponent,
  Visitor2Component,
  IncomeExpenssComponent,
  PostsComponent,
  NewsletterComponent,
  DeveloperInfoComponent,
  ActivityComponent,
  TopCard2Component,
  SalesPurchaseComponent,
  SalesYearlyComponent,
  ContactListComponent,
  CommentsComponent,
  MessageComponent,
} from './dashboard-components';
import { DashboardEmpComponent } from './dashboard-components/dashboard-emp/dashboard-emp.component';
import { EmpDialogComponent } from './dashboard-components/dashboard-emp/emp-dialog/emp-dialog.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { NgApexchartsModule } from 'ng-apexcharts';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatTabsModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    NgApexchartsModule,
    MatProgressBarModule
  ],
  declarations: [
    Dashboard1Component,
    Dashboard2Component,
    SalesOverviewComponent,
    VisitorComponent,
    Visitor2Component,
    IncomeExpenssComponent,
    PostsComponent,
    NewsletterComponent,
    DeveloperInfoComponent,
    ActivityComponent,
    TopCard2Component,
    SalesPurchaseComponent,
    SalesYearlyComponent,
    ContactListComponent,
    CommentsComponent,
    MessageComponent,
    DashboardEmpComponent,
    EmpDialogComponent,
    TopCardComponent,
  ],
  entryComponents: [EmpDialogComponent],
})
export class DashboardsModule {}
