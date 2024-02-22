import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListSaleComponent } from './components/list-sale/list-sale.component';
import { SalesRoutingModule } from './sale-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    ListSaleComponent,
  ],
  imports: [
    CommonModule,
    SalesRoutingModule,
    SharedModule
  ],
})
export class SalesModule { }
