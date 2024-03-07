import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/shared/services/auth.guard';
import { StockTabComponent } from './components/stock-tab/stock-tab.component';

const routes: Routes = [
    { path: '', component: StockTabComponent ,canActivate:[AuthGuard],},
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class StockRoutingModule { }