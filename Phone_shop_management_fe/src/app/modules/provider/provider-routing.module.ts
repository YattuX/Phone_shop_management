import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListProviderComponent } from './components/list-provider.component';

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                component: ListProviderComponent,
                data: {
                    title: 'Liste des Fournisseurs'
                }
            },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ProviderRoutingModule { }