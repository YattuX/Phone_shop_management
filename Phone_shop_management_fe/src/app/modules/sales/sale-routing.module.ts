import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListSaleComponent } from './components/list-sale/list-sale.component';
import { AuthGuard } from 'src/app/shared/services/auth.guard';

const routes: Routes = [
    { path: '', component: ListSaleComponent,canActivate:[AuthGuard], },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class SalesRoutingModule { }