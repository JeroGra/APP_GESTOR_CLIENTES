import { Component, EventEmitter, Output } from '@angular/core';
import { Cliente } from 'src/app/modelos/Cliente';
import { ApiService } from 'src/app/servicios/api.service';

@Component({
  selector: 'app-lista-clientes',
  templateUrl: './lista-clientes.component.html',
  styleUrls: ['./lista-clientes.component.scss']
})
export class ListaClientesComponent {

  clientes : Cliente[] = []
  @Output() clienteSeleccionadoEvent = new EventEmitter<Cliente>;
  
  constructor(private api : ApiService){
    try
    {
      this.api.listarClientes(localStorage.getItem("token") as string).subscribe((data:Cliente[]) => { this.clientes = data});

    }catch(e)
    {

    }
  }

  select(cliente:Cliente)
  {
    this.clienteSeleccionadoEvent.emit(cliente);
  }

}
