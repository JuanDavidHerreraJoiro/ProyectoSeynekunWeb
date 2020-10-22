import { Component, OnInit } from '@angular/core';
import { MaterialModule } from 'src/app/material';

@Component({
  selector: 'app-interfaz-inicial',
  templateUrl: './interfaz-inicial.component.html',
  styleUrls: ['./interfaz-inicial.component.css'],

})
export class InterfazInicialComponent implements OnInit {
  imports: [MaterialModule]; /*importo mi clase material para usuar los componentes de angular materia*/
  constructor() { }

  ngOnInit(): void {
  }

  onExit(): void {
  }

}

