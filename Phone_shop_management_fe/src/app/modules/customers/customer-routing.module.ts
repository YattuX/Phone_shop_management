import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCustomerComponent } from './components/list-customer.component';
import { CustomerTabComponent } from './components/customer-tab.component';

 const routes: Routes = [
    {
        path: '',
        children: [
            {
                path:'',
                component:CustomerTabComponent,
                data: {
                    title: "Liste des clients",
                }
            },
        ]
    },
];

export const customerRoutes = routes[0].children?.slice(1);

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerRoutingModule { }