import { registerLocaleData } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuardGuard } from './modules/auth/auth-guard.guard';
import { LoginComponent } from './modules/auth/login/login.component';
import { RegisterComponent } from './modules/auth/register/register.component';
import { ManufacturerDetailComponent } from './modules/manufacturers/manufacturer-detail/manufacturer-detail.component';
import { ManufacturersComponent } from './modules/manufacturers/manufacturers/manufacturers.component';

const routes: Routes = [
  {path : '', redirectTo: '/dashboard', pathMatch: 'full'},
  {path : 'login', component : LoginComponent},
  {path : 'register', component : RegisterComponent},
  {path : 'manufacturer-detail/:id', component: ManufacturerDetailComponent },
  {path: 'manufacturers', component: ManufacturersComponent, canActivate: [AuthGuardGuard] },
  {path: 'dashboard', component: DashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
