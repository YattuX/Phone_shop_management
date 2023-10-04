import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPaiementComponent } from './components/list-paiement/list-paiement.component';
import { AuthGuard } from 'src/app/shared/services/auth.guard';

const routes: Routes = [
    { path: '', component: ListPaiementComponent,canActivate:[AuthGuard], },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class PaiementRoutingModule { }