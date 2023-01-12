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


@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    SidebarComponent,
    FooterComponent,
    FooterOnlyLayoutComponent,
    AgentsLayoutComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    DashboardModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgToastModule
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
