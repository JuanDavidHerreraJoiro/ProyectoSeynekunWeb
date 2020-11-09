import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { ClienteService } from '../../services/cliente.service';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import {NestedTreeControl} from '@angular/cdk/tree';
import { MaterialModule } from 'src/app/material';
import { Router } from '@angular/router';

interface FoodNode {
  name: string;
  ruta?: string;
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'HOME', ruta: '/interfazinicial',
  },  {
    name: 'CLIENTE',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteConsultar'},
    ]
  }, {
    name: 'FICHA TECNICA',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'PARAMETROS DE REFERENCIA',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  },  {
    name: 'MATERIALES',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'PROCESOS PRODUCCION',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'MANO DE OBRA',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'COSTOS INDIRECTOS',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  },  {
    name: 'COSTOS Y GASTOS MENSUALES',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'TRM',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'COSTEO GENERAL',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'MARGEN DE CONTRIBUCION',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'EXIT',
  },
];

@Component({
  selector: 'app-cliente-consultar',
  templateUrl: './cliente-consultar.component.html',
  styleUrls: ['./cliente-consultar.component.css']
})
export class ClienteConsultarComponent implements OnInit {

  imports: [MaterialModule]; /*importo mi clase material para usuar los componentes de angular materia*/
  treeControl = new NestedTreeControl<FoodNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<FoodNode>();

  /*cliente: Cliente;*/
  clientes: Cliente[];
  cliente: Cliente;
  constructor(
    private clienteService: ClienteService,
    private router: Router
    ) {
    this.dataSource.data = TREE_DATA;
  }

  hasChild = (_: number, node: FoodNode) => !!node.children && node.children.length > 0;

  ngOnInit() {
    this.refrescar();
  }

  delete(identificacion: string) {
    this.clienteService.delete(identificacion).subscribe(result => {
      console.log('eliminado');
      this.refrescar();
    });
  }

  getIdentificacion(searchText: string) {
    this.clienteService.getIdentificacion(searchText).subscribe(result => {
      if (result != null) {
        this.cliente = result;
        this.clientes.splice(0);
        this.clientes.push(this.cliente);
      } else {
        this.clientes.splice(0);
        this.ngOnInit();
      }
    });
  }

  update(identificacion: string) {
    this.router.navigate(['/clienteModificarEliminar/' + identificacion]);
  }

  refrescar() {
    this.clienteService.get().subscribe(result => {
      this.clientes = result;
    });
  }

}
