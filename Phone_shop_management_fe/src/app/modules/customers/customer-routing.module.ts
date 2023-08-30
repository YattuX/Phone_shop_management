import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCustomerComponent } from './components/list-customer/list-customer.component';

const routes: Routes = [
    { path: '', component: ListCustomerComponent },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerRoutingModule { }