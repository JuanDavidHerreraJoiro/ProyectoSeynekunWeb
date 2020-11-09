import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { ClienteService } from '../../services/cliente.service';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MaterialModule } from 'src/app/material';
import Swal from 'sweetalert2';
import { HandleHttpErrorService } from '../../@base/handle-http-error.service';
import { HttpHeaders, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';


interface FoodNode {
  name: string;
  ruta?: string;
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'HOME', ruta: '/interfazinicial',
  }, {
    name: 'CLIENTE',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteConsultar' },
    ]
  }, {
    name: 'FICHA TECNICA',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'PARAMETROS DE REFERENCIA',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'MATERIALES',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'PROCESOS PRODUCCION',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'MANO DE OBRA',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'COSTOS INDIRECTOS',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'COSTOS Y GASTOS MENSUALES',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'TRM',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'COSTEO GENERAL',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'MARGEN DE CONTRIBUCION',
    children: [
      { name: 'GUARDAR', ruta: '/clienteRegistro' },
      { name: 'CONSULTAR', ruta: '/clienteRegistro' },
    ]
  }, {
    name: 'EXIT',
  },
];

@Component({
  selector: 'app-cliente-registro',
  templateUrl: './cliente-registro.component.html',
  styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {

  imports: [MaterialModule]; /*importo mi clase material para usuar los componentes de angular materia*/
  treeControl = new NestedTreeControl<FoodNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<FoodNode>();

  cliente: Cliente;
  constructor(private clienteService: ClienteService) {
    this.dataSource.data = TREE_DATA;
  }

  hasChild = (_: number, node: FoodNode) => !!node.children && node.children.length > 0;

  ngOnInit() {
    this.cliente = new Cliente();
  }
  add() {
    this.clienteService.post(this.cliente).subscribe(p => {
      if (p != null) {
        alert('CLIENTE CREADO!');
        console.log(p);

        Swal.fire(
          'REGISTRO EXITOSO!',
          'success'
          );

      } else {
        console.log(p);
        Swal.fire({
          icon: 'error',
          title: 'REGISTRO FALLIDO!',
          text: 'Algo salió mal!',
          /*footer: '<a href> Why do I have this issue? </a>' HttpErrorResponse*/
        });
      }
    });
  }

}
