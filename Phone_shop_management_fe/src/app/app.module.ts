import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { ProductRoutingModule } from './modules/product/product-routing.module';
import { SharedModule } from './shared/shared.module';
import { CommonModule } from '@angular/common';
import { ProductModule } from './modules/product/product.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UsersModule } from './modules/users/users.module';
import { CustomerModule } from './modules/customers/customer.module';
import { ProviderModule } from './modules/provider/provider.module';
import { MatChipsModule } from '@angular/material/chips';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { CustomPaginatorIntl } from './shared/global/custom-paginator-intl';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './shared/interceptors/AuthInterceptors/auth-Interceptor';
import { ConfigurationModule } from './modules/configuration/configuration.module';
import { DashboardsModule } from './shared/components/dashboards/dashboards.module';
import { RepairModule } from './modules/repair/repair.module';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    ProductRoutingModule,
    SharedModule,
    ProductModule,
    BrowserAnimationsModule,
    UsersModule,
    CustomerModule,
    MatChipsModule,
    ProviderModule,
    ConfigurationModule,
    DashboardsModule,
    RepairModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
 
  providers: [
    { provide: MatPaginatorIntl, useClass: CustomPaginatorIntl },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
  exports:[]
})
export class AppModule { }
