import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { Usuario } from '../models/usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router) { }
  private usuario: Usuario = {
    email: '',
    password: ''
  };

  ngOnInit() {}

  onLogin() {
    return this.loginService.loginuser(this.usuario.email, this.usuario.password)
    .subscribe(usuario => {
      this.loginService.setUser(usuario.usuario);
      const token = usuario.id;
      /* CAMBIAR RUTA */
      this.loginService.setToken(token);
      this.router.navigate(['/seynekun/cliente-consular']);
      /*console.log(data);*/
    },
    error => console.log(error)
    );
  }
}
