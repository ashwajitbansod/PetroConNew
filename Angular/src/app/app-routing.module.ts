import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { UserComponent } from './Components/user/user.component';
import { AuthGuard } from './Services/auth/auth.guard';
import { AfterLoginLayoutComponent } from './Components/login/after.login.component';
import { BeforeLoginLayoutComponent } from './Components/login/before.login.component';


const routes: Routes = [
  // { path: 'home', component: HomeComponent },
  // { path: '', component: LoginComponent },
  // { path: 'login', component: LoginComponent },
  // { path: 'user', component: UserComponent },

  {
    path: '',
    component: AfterLoginLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: HomeComponent
      } , { path: 'user', component: UserComponent },
    ]
  },
  {
    path: '',
    component: BeforeLoginLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent},
     
    ]
  },
  { path: '**', redirectTo: '' }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
