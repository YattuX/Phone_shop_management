import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './components/product-list.component';
import { ProductRoutingModule } from './product-routing.module';
import { AppBreadcrumbComponent } from 'src/app/shared/components/layouts/breadcrumb/breadcrumb.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProductDialog } from './components/product.dialog';
import { PieceComponent } from './components/piece/piece.component';
import { AccessoirComponent } from './components/accessoir/accessoir.component';
import { MaterielComponent } from './components/materiel/materiel.component';




@NgModule({
  declarations: [
    ProductListComponent,
    ProductDialog,
    PieceComponent,
    AccessoirComponent,
    MaterielComponent,
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    SharedModule
  ]
})
export class ProductModule { }
