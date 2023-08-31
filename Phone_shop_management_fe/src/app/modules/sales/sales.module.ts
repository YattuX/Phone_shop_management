import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListSaleComponent } from './components/list-sale/list-sale.component';
import { SalesRoutingModule } from './sale-routing.module';



@NgModule({
  declarations: [
    ListSaleComponent
  ],
  imports: [
    CommonModule,
    SalesRoutingModule
  ]
})
export class SalesModule { }
