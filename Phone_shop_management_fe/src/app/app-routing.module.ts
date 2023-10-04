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
import { AuthGuard } from './shared/services/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    canActivate:[AuthGuard],
    children: [
      {
        path:'',
        redirectTo:'dashboard',
        pathMatch:'full'
      },
      {
        path:'dashboard',
        canActivate:[AuthGuard],
        loadChildren:()=>DashboardRoutingModule
      },
      {
        path: 'products',
        canActivate:[AuthGuard],
        loadChildren:()=>ProductRoutingModule,
      },
      {
        path:'customer',
        canActivate:[AuthGuard],
        loadChildren:()=>CustomerRoutingModule,
      },
      {
        path:'provider',
        canActivate:[AuthGuard],
        loadChildren:()=>ProviderRoutingModule,
      },
      {
        path:"stock",
        canActivate:[AuthGuard],
        loadChildren:()=>StockRoutingModule,
      },
      {
        path:"sales",
        canActivate:[AuthGuard],
        loadChildren:()=>SalesRoutingModule,
      },
      {
        path:"paiement",
        canActivate:[AuthGuard],
        loadChildren:()=>PaiementRoutingModule,
      },
      {
        path:'repair',
        canActivate:[AuthGuard],
        loadChildren:()=>RepairRoutingModule
      },
      {
        path:'config',
        canActivate:[AuthGuard],
        loadChildren:()=>ConfigurationRoutingModule
      },
      {
        path:'users',
        canActivate:[AuthGuard],
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
