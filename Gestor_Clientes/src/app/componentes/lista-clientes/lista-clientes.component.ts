import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Cliente } from 'src/app/modelos/Cliente';
import { ApiService } from 'src/app/servicios/api.service';

@Component({
  selector: 'app-lista-clientes',
  templateUrl: './lista-clientes.component.html',
  styleUrls: ['./lista-clientes.component.scss']
})
export class ListaClientesComponent {

  @Output() clienteSeleccionadoEvent = new EventEmitter<Cliente>;
  @Input() clientes : Array<Cliente> = []

  constructor(){

  }

  select(cliente:Cliente)
  {
    this.clienteSeleccionadoEvent.emit(cliente);
  }




}
