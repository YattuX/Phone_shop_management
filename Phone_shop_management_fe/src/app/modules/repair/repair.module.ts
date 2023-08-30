import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListRepairComponent } from './components/list-repair/list-repair.component';
import { RepairRoutingModule } from './repair-routing.module';



@NgModule({
  declarations: [
    ListRepairComponent
  ],
  imports: [
    CommonModule,
    RepairRoutingModule
  ]
})
export class RepairModule { }
