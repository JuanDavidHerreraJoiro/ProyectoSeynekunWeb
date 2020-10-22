import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './seynekun/login/login.component';
import { LoginRegistroComponent } from './seynekun/login-registro/login-registro.component';
import { ClienteRegistroComponent } from './seynekun/cliente-registro/cliente-registro.component';
import { ClienteConsultarComponent } from './seynekun/cliente-consultar/cliente-consultar.component';
import { ClienteModificarEliminarComponent } from './seynekun/cliente-modificar-eliminar/cliente-modificar-eliminar.component';
import { InterfazInicialComponent } from './seynekun/interfaz-inicial/interfaz-inicial.component';
import { HomeSeynekunComponent } from './seynekun/home-seynekun/home-seynekun.component';

import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {
        path: 'clienteRegistro',
        component: ClienteRegistroComponent
    },

    {
          path: 'clienteConsultar',
          component: ClienteConsultarComponent
    },

    {
          path: 'clienteModificarEliminar/:identificacion',
          component: ClienteModificarEliminarComponent
    },

    {
          path: 'login',
          component: LoginComponent
    },

    {
          path: 'loginRegistro',
          component: LoginRegistroComponent
    },

    {
          path: 'interfazinicial',
          component: InterfazInicialComponent
    },

    {
          path: 'homeseynekun',
          component: HomeSeynekunComponent
    }
  ];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
