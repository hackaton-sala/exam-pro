import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoPageFoundComponent } from './error/nopagefound/nopagefound.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ListeningComponent } from './listening/listening.component';
import {Reading1Component} from "./reading1/reading1.component";
import {Reading5Component} from "./reading5/reading5.component";

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'listening', component: ListeningComponent},
  {path: 'reading1', component: Reading1Component},
  {path: 'reading5', component: Reading5Component},
  {path: 'nopagefound', component: NoPageFoundComponent},
  {path: '**', component: NoPageFoundComponent},
]

@NgModule({
  imports: [ RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
