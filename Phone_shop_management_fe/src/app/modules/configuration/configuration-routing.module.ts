import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListConfigComponent } from './components/list-config/list-config.component';

const routes: Routes = [
    { path: '', component: ListConfigComponent },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ConfigurationRoutingModule { }