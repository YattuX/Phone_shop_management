import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NotFoundComponent } from "./not-found/not-found.component";
import { LoginComponent } from "./login/login.component";

const routes: Routes = [
    { path: '404', component: NotFoundComponent },
    { path: 'login', component: LoginComponent },
]

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild(routes)
    ]
})
export class AuthRouting { }