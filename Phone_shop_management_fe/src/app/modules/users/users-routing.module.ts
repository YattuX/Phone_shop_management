import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListUsersComponent } from './components/list-users.component';
import { AuthGuard } from 'src/app/shared/services/auth.guard';

const routes: Routes = [
    { path: '', component: ListUsersComponent,canActivate:[AuthGuard], },
    // ... Autres routes spécifiques au module "Clients"
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UsersRoutingModule { }