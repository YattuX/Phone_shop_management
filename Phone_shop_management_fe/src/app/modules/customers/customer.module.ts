import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListCustomerComponent } from './components/list-customer/list-customer.component';
import { AddCustomerComponent } from './components/add-customer/add-customer.component';
import { CustomerRoutingModule } from './customer-routing.module';



@NgModule({
  declarations: [
    ListCustomerComponent,
    AddCustomerComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule
  ]
})
export class CustomerModule { }
