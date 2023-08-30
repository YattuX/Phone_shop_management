import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListStockComponent } from './components/list-stock/list-stock.component';
import { AddStockComponent } from './components/add-stock/add-stock.component';
import { StockRoutingModule } from './stock-routing.module';



@NgModule({
  declarations: [
    ListStockComponent,
    AddStockComponent
  ],
  imports: [
    CommonModule,
    StockRoutingModule
  ]
})
export class StockModule { }
