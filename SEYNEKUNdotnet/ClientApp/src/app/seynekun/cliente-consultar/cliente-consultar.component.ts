import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-cliente-consultar',
  templateUrl: './cliente-consultar.component.html',
  styleUrls: ['./cliente-consultar.component.css']
})
export class ClienteConsultarComponent implements OnInit {

  clientes: Cliente[];
  searchText: string;
  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.clienteService.get().subscribe(result => {
      this.clientes = result;
    });
  }
}
