import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListStockComponent } from './components/list-stock/list-stock.component';
import { AddStockComponent } from './components/add-stock/add-stock.component';
import { StockRoutingModule } from './stock-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { StockDialog } from './components/stock-dialog/stock.dialog';
import { AutoCompleteComponent } from 'src/app/shared/components/autocomplete/autocomplete.component';
import { EtatStockComponent } from './components/etat-stock/etat-stock.component';
import { StockTabComponent } from './components/stock-tab/stock-tab.component';



@NgModule({
  declarations: [
    ListStockComponent,
    AddStockComponent,
    StockDialog,
    EtatStockComponent,
    StockTabComponent,
    
  ],
  imports: [
    CommonModule,
    StockRoutingModule,
    SharedModule,
    AutoCompleteComponent,
  ],
  
})
export class StockModule { }
