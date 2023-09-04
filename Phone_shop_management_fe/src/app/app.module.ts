import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { UsersModule } from './modules/users/users.module';
import { ProductRoutingModule } from './modules/product/product-routing.module';
import { SharedModule } from './shared/shared.module';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './shared/spinner/spinner.component';
import { ProductModule } from './modules/product/product.module';

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
  ],
 
  providers: [
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
