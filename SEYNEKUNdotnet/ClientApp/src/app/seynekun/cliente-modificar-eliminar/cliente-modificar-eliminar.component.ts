import { Component, OnInit } from '@angular/core';
import { MaterialModule } from 'src/app/material';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../models/cliente';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import {NestedTreeControl} from '@angular/cdk/tree';
import { ActivatedRoute } from '@angular/router';

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
  selector: 'app-cliente-modificar-eliminar',
  templateUrl: './cliente-modificar-eliminar.component.html',
  styleUrls: ['./cliente-modificar-eliminar.component.css']
})
export class ClienteModificarEliminarComponent implements OnInit {

  imports: [MaterialModule]; /*importo mi clase material para usuar los componentes de angular materia*/
  treeControl = new NestedTreeControl<FoodNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<FoodNode>();

  cliente: Cliente;
  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute) {
    this.dataSource.data = TREE_DATA;
  }

  hasChild = (_: number, node: FoodNode) => !!node.children && node.children.length > 0;

  ngOnInit() {
    this.cliente = new Cliente();
    this.getid();
  }

  getid () {
    const id = +this.route.snapshot.paramMap.get('identificacion');
    this.clienteService.getIdentificacion(id + '').subscribe(cliente => this.cliente = cliente);
  }

  update () {
    this.clienteService.update(this.cliente).subscribe(result => {
      console.log('Modificado');
    });
  }

  delete(identificacion: string) {
    this.clienteService.delete(identificacion).subscribe(result => {
      console.log('eliminado');
    });
  }
}
