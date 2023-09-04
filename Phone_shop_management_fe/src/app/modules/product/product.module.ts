import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductRoutingModule } from './product-routing.module';
import { AppBreadcrumbComponent } from 'src/app/shared/components/layouts/breadcrumb/breadcrumb.component';
import { SharedModule } from 'src/app/shared/shared.module';




@NgModule({
  declarations: [
    ProductListComponent,
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    SharedModule
  ]
})
export class ProductModule { }
