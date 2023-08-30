import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListPaiementComponent } from './components/list-paiement/list-paiement.component';
import { PaiementRoutingModule } from './paiment-routing.module';



@NgModule({
  declarations: [
    ListPaiementComponent
  ],
  imports: [
    CommonModule,
    PaiementRoutingModule
  ]
})
export class PaiementModule { }
