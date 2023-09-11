import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCustomerComponent } from './components/list-customer.component';
import { CustomerTabComponent } from './components/customer-tab.component';

 const routes: Routes = [
    {
        path: '',
        component:CustomerTabComponent,//<= le parent
        children: [
            {
                path:'',
                redirectTo:'list',
                pathMatch:'full',
            },
            {
                path: 'list',
                component: ListCustomerComponent,
                data: {
                    title: "Liste des clients",
                    isClientEnGros:false
                }
            },
            {
                path:'wholesale',
                component:ListCustomerComponent,
                data:{
                    title:"Liste des clients en gros",
                    isClientEnGros:true
                }
            }
        ]
    },
];

export const customerRoutes = routes[0].children?.slice(1);

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerRoutingModule { }