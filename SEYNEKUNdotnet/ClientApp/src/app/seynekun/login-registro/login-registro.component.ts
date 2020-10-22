import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario';
import { Location } from '@angular/common';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-registro',
  templateUrl: './login-registro.component.html',
  styleUrls: ['./login-registro.component.css']
})

export class LoginRegistroComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router, private location: Location ) { }

  private usuario: Usuario = {
    nombre: '',
    email: '',
    password: ''
  };

  public isError = false;
  public msgError = '';

  ngOnInit() {}

  onRegister(form: NgForm): void {
    if (form.valid) {
      this.loginService
        .registerUser(this.usuario.nombre, this.usuario.email, this.usuario.password)
        .subscribe( usuario => {
          this.loginService.setUser(usuario);
          const token = usuario.token;
          this.loginService.setToken(token);
          /* CAMBIAR RUTA */
          this.router.navigate(['/seynekun/cliente-consular']);
          location.reload();
        },
        res => {
          console.log(res);
          /*
          this.msgError = res.error.error.de;
          this.onIsError();*/
        });
    } else {
      this.onIsError();
    }
  }

  onIsError(): void {
    this.isError = true;
    setTimeout(() => {
      this.isError = false;
    }, 4000);
  }

}
