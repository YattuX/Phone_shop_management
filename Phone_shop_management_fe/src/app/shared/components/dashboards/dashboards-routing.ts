import { RouterModule, Routes } from '@angular/router';

import { Dashboard1Component } from './dashboard1/dashboard1.component';
import { NgModule } from '@angular/core';

export const DashboardsRoutes: Routes = [
  {
    path: '',
    component: Dashboard1Component,
    data: {
      title: 'Tableau de bord',
      urls: [{ title: 'Tableau de bord', url: '/dashboard' },],
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(DashboardsRoutes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule { }
