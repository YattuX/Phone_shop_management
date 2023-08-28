import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';

const routes: Routes = [
    {
        path: '', component: ProductListComponent,
        data: {
            title: "Articles",
            urls: [{ title: "", url: "/dashboard" ,icon: "home"},{title:'Articles', icon: "receipt",url:'/products'}, { title: "Ajout Articles" }],
            // indexComponent: MENU_INDEX.LIVRAISON_DES_CLIENTS,
            // action: "create"
        },
    },
    // ... Autres routes spécifiques au module "Produits"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ProductRoutingModule { }
