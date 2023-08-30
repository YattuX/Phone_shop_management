import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListRepairComponent } from './components/list-repair/list-repair.component';

const routes: Routes = [
    { path: '', component: ListRepairComponent },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class RepairRoutingModule { }