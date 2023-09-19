import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list.component';

const routes: Routes = [
    {
        path: 'appareil', 
        component: ProductListComponent,
        data: { 
            title: 'Liste des articles'
        } 
    },
    {
        path: 'piece', 
        component: ProductListComponent,
        data: { 
            title: 'Liste des pièces'
        } 
    },
    {
        path: 'accessoir', 
        component: ProductListComponent,
        data: { 
            title: 'Liste des accessoirs'
        } 
    },
    {
        path: 'materiel', 
        component: ProductListComponent,
        data: { 
            title: 'Liste matériels'
        } 
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ProductRoutingModule { }
