import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ApplicationComponent } from './application.component';
import { UsersComponent } from './users/users.component';



@NgModule({
  declarations: [
    UsersComponent,
    ApplicationComponent
  ],
  exports: [
    ApplicationComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ApplicationModule { }
