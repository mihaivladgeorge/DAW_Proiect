import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManufacturersComponent } from './modules/manufacturers/manufacturers/manufacturers.component';
import { ManufacturerDetailComponent } from './modules/manufacturers/manufacturer-detail/manufacturer-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './modules/auth/login/login.component';
import { JwtModule } from '@auth0/angular-jwt';
import { RegisterComponent } from './modules/auth/register/register.component';

import { AuthModule } from './modules/auth/auth.module';
import { ManufacPipe } from './manufac.pipe';
import { DashDirective } from './dash.directive';
import { IdpipePipe } from './idpipe.pipe';

@NgModule({
  declarations: [
    RegisterComponent,
    AppComponent,
    ManufacturersComponent,
    ManufacturerDetailComponent,
    MessagesComponent,
    DashboardComponent,
    LoginComponent,
    ManufacPipe,
    DashDirective,
    IdpipePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter : () => {
          return localStorage.getItem("token");
        }
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
