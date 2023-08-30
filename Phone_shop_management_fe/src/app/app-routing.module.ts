import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductRoutingModule } from './modules/product/product-routing.module';
import { FullComponent } from './shared/components/layouts/full/full.component';
import { AppBlankComponent } from './shared/components/layouts/blank/blank.component';
import { AuthRouting } from './modules/auth/auth-routing.module';
import {DashboardRoutingModule } from './shared/components/dashboards/dashboards-routing';
import { CustomerRoutingModule } from './modules/customers/customer-routing.module';
import { ProviderRoutingModule } from './modules/provider/provider-routing.module';
import { StockRoutingModule } from './modules/stock/stock-routing.module';
import { SalesRoutingModule } from './modules/sales/sale-routing.module';
import { PaiementRoutingModule } from './modules/paiement/paiment-routing.module';
import { RepairRoutingModule } from './modules/repair/repair-routing.module';
import { ConfigurationRoutingModule } from './modules/configuration/configuration-routing.module';
import { UsersRoutingModule } from './modules/users/users-routing.module';

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
      },
      {
        path:'customer',
        loadChildren:()=>CustomerRoutingModule,
      },
      {
        path:'provider',
        loadChildren:()=>ProviderRoutingModule,
      },
      {
        path:"stock",
        loadChildren:()=>StockRoutingModule,
      },
      {
        path:"sales",
        loadChildren:()=>SalesRoutingModule,
      },
      {
        path:"paiement",
        loadChildren:()=>PaiementRoutingModule,
      },
      {
        path:'repair',
        loadChildren:()=>RepairRoutingModule
      },
      {
        path:'config',
        loadChildren:()=>ConfigurationRoutingModule
      },
      {
        path:'users',
        loadChildren:()=>UsersRoutingModule
      },
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
  imports: [RouterModule.forRoot(routes), ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
