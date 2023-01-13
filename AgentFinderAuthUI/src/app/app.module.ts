import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LoginModule } from './components/login/login.module'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SignupComponent } from './components/signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { MenuOptionsService } from 'src/app/services/menu-options.service';
import { NgToastModule } from 'ng-angular-popup';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { SidebarComponent } from './shared/components/sidebar/sidebar.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { FooterOnlyLayoutComponent } from './shared/layouts/footer-only-layout/footer-only-layout.component';
import { AgentsLayoutComponent } from './shared/layouts/agents-layout/agents-layout.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { DashboardModule } from './components/dashboard/dashboard.module';
import { HomeComponent } from './components/home/home.component';
import { HeaderFooterLayoutComponent } from './shared/layouts/header-footer-layout/header-footer-layout.component';
import { DashboardHeaderComponent } from './shared/components/dashboard-header/dashboard-header.component';
import { AgentRegisterComponent } from './components/agent-register/agent-register.component';
import { AgentProfileComponent } from './components/agent-profile/agent-profile.component';
import { AgentsComponent } from './components/agents/agents.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDividerModule } from '@angular/material/divider';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { ContactInboxComponent } from './components/contact-inbox/contact-inbox.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    SidebarComponent,
    FooterComponent,
    FooterOnlyLayoutComponent,
    AgentsLayoutComponent,
    HeaderComponent,
    HomeComponent,
    HeaderFooterLayoutComponent,
    DashboardHeaderComponent,
    AgentRegisterComponent,
    AgentProfileComponent,
    AgentsComponent,
    ContactInboxComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    DashboardModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgToastModule,
    MatGridListModule,
    MatDividerModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  },
  MenuOptionsService
],
  bootstrap: [AppComponent]
})
export class AppModule { }
