import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductRoutingModule } from './modules/product/product-routing.module';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { LoginComponent } from './shared/components/login/login.component';

const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' }, // Redirection par défaut
  { path: '404', component: NotFoundComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '/404' },
  // ... Autres routes globales
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ProductRoutingModule], // Importez les routes spécifiques des modules
  exports: [RouterModule],
})
export class AppRoutingModule { }
