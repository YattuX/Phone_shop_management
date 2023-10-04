import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListStockComponent } from './components/list-stock/list-stock.component';
import { AuthGuard } from 'src/app/shared/services/auth.guard';

const routes: Routes = [
    { path: '', component: ListStockComponent ,canActivate:[AuthGuard],},
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class StockRoutingModule { }