import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListRepairComponent } from './components/list-repair/list-repair.component';
import { RepairRoutingModule } from './repair-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AutoCompleteComponent } from 'src/app/shared/components/autocomplete/autocomplete.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { AddReparationDialog } from './components/add-reparation/add-reparation.component';


@NgModule({
  declarations: [
    ListRepairComponent,
    AddReparationDialog
  ],
  imports: [
    CommonModule,
    RepairRoutingModule,
    SharedModule,
    AutoCompleteComponent,
    MatDatepickerModule
  ]
})
export class RepairModule { }
