import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-cliente-registro',
  templateUrl: './cliente-registro.component.html',
  styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {

  cliente: Cliente;
  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.cliente = new Cliente();
  }
  add() {
    this.clienteService.post(this.cliente).subscribe(p => {
      if (p != null) {
        alert('CLIENTE CREADO!');
        this.cliente = p;
      }
    });
  }
}
