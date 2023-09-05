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
  ],
 
  providers: [
  ],
  bootstrap: [AppComponent],
  exports:[]
})
export class AppModule { }
