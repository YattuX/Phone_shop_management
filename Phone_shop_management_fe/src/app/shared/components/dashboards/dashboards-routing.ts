import { RouterModule, Routes } from '@angular/router';

import { Dashboard1Component } from './dashboard1/dashboard1.component';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../../services/auth.guard';

export const DashboardsRoutes: Routes = [
  {
    path: '',
    component: Dashboard1Component,
    canActivate: [AuthGuard],
    data: {
      title: 'Tableau de bord',
      urls: [{ title: '', url: '/dashboard', icon: 'home' },],
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(DashboardsRoutes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule { }
