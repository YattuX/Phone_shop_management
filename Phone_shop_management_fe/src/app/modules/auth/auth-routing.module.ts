import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NotFoundComponent } from "./not-found/not-found.component";
import { LoginComponent } from "./login/login.component";
import { AuthGuard } from "src/app/shared/services/auth.guard";

const routes: Routes = [
    { path: '404', component: NotFoundComponent, canActivate:[AuthGuard] },
    { path: 'login', component: LoginComponent },
]

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild(routes)
    ]
})
export class AuthRouting { }