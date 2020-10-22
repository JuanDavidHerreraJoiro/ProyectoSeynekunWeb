import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AppRoutingModule } from './app-routing.module';
import { ClienteRegistroComponent } from './seynekun/cliente-registro/cliente-registro.component';
import { ClienteConsultarComponent } from './seynekun/cliente-consultar/cliente-consultar.component';
import { ClienteModificarEliminarComponent } from './seynekun/cliente-modificar-eliminar/cliente-modificar-eliminar.component';
import { ClienteService } from './services/cliente.service';
import { LoginComponent } from './seynekun/login/login.component';
import { LoginRegistroComponent } from './seynekun/login-registro/login-registro.component';
import { InterfazInicialComponent } from './seynekun/interfaz-inicial/interfaz-inicial.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material';
import { HomeSeynekunComponent } from './seynekun/home-seynekun/home-seynekun.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteRegistroComponent,
    ClienteConsultarComponent,
    ClienteModificarEliminarComponent,
    LoginComponent,
    LoginRegistroComponent,
    InterfazInicialComponent,
    HomeSeynekunComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MaterialModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent],

})
export class AppModule { }
