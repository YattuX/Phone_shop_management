import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductRoutingModule } from './modules/product/product-routing.module';
import { FullComponent } from './shared/components/layouts/full/full.component';
import { AppBlankComponent } from './shared/components/layouts/blank/blank.component';
import { AuthRouting } from './modules/auth/auth-routing.module';
import {DashboardRoutingModule } from './shared/components/dashboards/dashboards-routing';

const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path:'',
        redirectTo:'dashboard',
        pathMatch:'full'
      },
      {
        path:'dashboard',
        loadChildren:()=>DashboardRoutingModule
      },
      {
        path: 'products',
        loadChildren:()=>ProductRoutingModule,
      }
    ]
  },
  {
    path: '',
    component: AppBlankComponent,
    children:[
      {
        path:'auth',
        loadChildren:()=>AuthRouting
      }
    ]
  },
  { path: '**', redirectTo: 'auth/404' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ], // Importez les routes spécifiques des modules
  exports: [RouterModule],
})
export class AppRoutingModule { }
