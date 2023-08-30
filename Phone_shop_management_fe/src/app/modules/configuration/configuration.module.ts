import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListConfigComponent } from './components/list-config/list-config.component';
import { ConfigurationRoutingModule } from './configuration-routing.module';



@NgModule({
  declarations: [
    ListConfigComponent
  ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule
  ]
})
export class ConfigurationModule { }
