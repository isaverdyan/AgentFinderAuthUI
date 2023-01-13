import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AgentProfileComponent } from './components/agent-profile/agent-profile.component';
import { AgentRegisterComponent } from './components/agent-register/agent-register.component';
import { AgentsComponent } from './components/agents/agents.component';
import { ContactInboxComponent } from './components/contact-inbox/contact-inbox.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AuthGuard } from './guards/auth.guard';
import { AgentsLayoutComponent } from './shared/layouts/agents-layout/agents-layout.component';
import { HeaderFooterLayoutComponent } from './shared/layouts/header-footer-layout/header-footer-layout.component';

const routes: Routes = [
  {path:'signup', component: SignupComponent},
  {path: '',
    component: HeaderFooterLayoutComponent,
    children: [
        {path:'', component: HomeComponent}
  ]
  },
  {path: 'agent-join', component: AgentRegisterComponent},
  {path: 'agent-profile',
    component: AgentsLayoutComponent,
    children: [
        {path:'', component: AgentProfileComponent}
  ]
  },
  {path: 'agents', component: HeaderFooterLayoutComponent,
        children: [
          {path:'', component: AgentsComponent}
        ]
 },
 {path: 'contact-inbox', component: HeaderFooterLayoutComponent,
      children: [
        {path:'', component: ContactInboxComponent}
      ] }
  // {path: '', component: HomeComponent},
  // {path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
