import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPaiementComponent } from './components/list-paiement/list-paiement.component';

const routes: Routes = [
    { path: '', component: ListPaiementComponent },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class PaiementRoutingModule { }