import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../guards/auth.guard';
import { AgentsLayoutComponent } from '../../shared/layouts/agents-layout/agents-layout.component';
import {DashboardComponent} from './dashboard.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: AgentsLayoutComponent,
    children: [
        {path:'', component: DashboardComponent, canActivate:[AuthGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
