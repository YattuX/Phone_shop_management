import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListStockComponent } from './components/list-stock/list-stock.component';

const routes: Routes = [
    { path: '', component: ListStockComponent },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class StockRoutingModule { }