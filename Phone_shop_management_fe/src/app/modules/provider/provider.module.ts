import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProviderRoutingModule } from './provider-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListProviderComponent } from './components/list-provider.component';
import { ProviderDialog } from './components/provider.dialog';



@NgModule({
  declarations: [
    ListProviderComponent,
    ProviderDialog
  ],
  imports: [
    CommonModule,
    ProviderRoutingModule,
    SharedModule,
  ]
})
export class ProviderModule { }
