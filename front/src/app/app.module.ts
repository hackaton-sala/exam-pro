import { HttpClientModule } from '@angular/common/http';
import { ApplicationModule, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoPageFoundComponent } from './error/nopagefound/nopagefound.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './services/application/user.service';
import { AuthService } from './services/common/auth.service';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { DesplegableComponent } from './desplegable/desplegable.component';
import { listenerCount } from 'process';
import { ListeningComponent } from './listening/listening.component';
import {Reading1Component} from "./reading1/reading1.component";
import {Reading5Component} from "./reading5/reading5.component";

@NgModule({
  declarations: [
    LoginComponent,
    NoPageFoundComponent,
    AppComponent,
    RegisterComponent,
    ListeningComponent,
    HeaderComponent,
    FooterComponent,
    DesplegableComponent,
    Reading5Component,
    Reading1Component


  ],
  imports: [
    AppRoutingModule,
    ApplicationModule,
    HttpClientModule,
    BrowserModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    ReactiveFormsModule,
    Reading1Component,
    Reading1Component
  ],
  providers: [
    AuthService,
    UserService,
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
