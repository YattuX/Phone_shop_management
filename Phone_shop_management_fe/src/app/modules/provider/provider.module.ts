import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListProviderComponent } from './components/list-provider/list-provider.component';
import { AddProviderComponent } from './components/add-provider/add-provider.component';
import { ProviderRoutingModule } from './provider-routing.module';



@NgModule({
  declarations: [
    ListProviderComponent,
    AddProviderComponent
  ],
  imports: [
    CommonModule,
    ProviderRoutingModule
  ]
})
export class ProviderModule { }
