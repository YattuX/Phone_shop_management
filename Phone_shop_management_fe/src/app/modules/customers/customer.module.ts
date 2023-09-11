import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListCustomerComponent } from './components/list-customer.component';
import { CustomerDialog } from './components/customer.dialog';
import { CustomerRoutingModule } from './customer-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerTabComponent } from './components/customer-tab.component';



@NgModule({
  declarations: [
    ListCustomerComponent,
    CustomerDialog,
    CustomerTabComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    SharedModule,
    
  ]
})
export class CustomerModule { }
