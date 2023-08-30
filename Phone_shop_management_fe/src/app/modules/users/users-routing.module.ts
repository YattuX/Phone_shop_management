import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListUsersComponent } from './components/list-users/list-users.component';

const routes: Routes = [
    { path: '', component: ListUsersComponent },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UsersRoutingModule { }