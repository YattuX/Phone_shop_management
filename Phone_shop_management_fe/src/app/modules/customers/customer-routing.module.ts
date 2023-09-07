import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCustomerComponent } from './components/list-customer.component';

const routes: Routes = [
    { path: '', 
    component: ListCustomerComponent,
    data: {
        title: "Liste des clients"
    }
 },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerRoutingModule { }