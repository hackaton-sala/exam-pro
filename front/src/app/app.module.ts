import { HttpClientModule } from '@angular/common/http';
import { ApplicationModule, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoPageFoundComponent } from './error/nopagefound/nopagefound.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './services/application/user.service';
import { AuthService } from './services/common/auth.service';



@NgModule({
  declarations: [
    LoginComponent,
    NoPageFoundComponent,
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    ApplicationModule,
    HttpClientModule,
    BrowserModule
  ],
  providers: [
    AuthService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
