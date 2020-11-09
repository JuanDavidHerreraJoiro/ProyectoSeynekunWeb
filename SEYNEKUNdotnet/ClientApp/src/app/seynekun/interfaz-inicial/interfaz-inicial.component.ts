import { Component, OnInit } from '@angular/core';
import { MaterialModule } from 'src/app/material';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import {NestedTreeControl} from '@angular/cdk/tree';

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
      {name: 'MODIFICAR', ruta: '/clienteModificarEliminar/:identificacion'},
      {name: 'ELIMINAR', ruta: '/clienteModificarEliminar/:identificacion'},
    ]
  }, {
    name: 'FICHA TECNICA',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'PARAMETROS DE REFERENCIA',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  },  {
    name: 'MATERIALES',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'PROCESOS PRODUCCION',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'MANO DE OBRA',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'COSTOS INDIRECTOS',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  },  {
    name: 'COSTOS Y GASTOS MENSUALES',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'TRM',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'COSTEO GENERAL',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'MARGEN DE CONTRIBUCION',
    children: [
      {name: 'GUARDAR', ruta: '/clienteRegistro'},
      {name: 'CONSULTAR', ruta: '/clienteRegistro'},
      {name: 'MODIFICAR', ruta: '/clienteRegistro'},
      {name: 'ELIMINAR', ruta: '/clienteRegistro'},
    ]
  }, {
    name: 'EXIT',
  },
];
@Component({
  selector: 'app-interfaz-inicial',
  templateUrl: './interfaz-inicial.component.html',
  styleUrls: ['./interfaz-inicial.component.css'],

})
export class InterfazInicialComponent implements OnInit {
  imports: [MaterialModule]; /*importo mi clase material para usuar los componentes de angular materia*/
  treeControl = new NestedTreeControl<FoodNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<FoodNode>();

  constructor() {
    this.dataSource.data = TREE_DATA;
  }
  hasChild = (_: number, node: FoodNode) => !!node.children && node.children.length > 0;

  ngOnInit(): void { }

  onExit(): void { }
}



