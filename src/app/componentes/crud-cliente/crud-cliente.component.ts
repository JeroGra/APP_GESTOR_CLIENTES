import { Component } from '@angular/core';
import { Cliente } from 'src/app/modelos/Cliente';
import { ApiService } from 'src/app/servicios/api.service';
import { LogService } from 'src/app/servicios/log.service';

@Component({
  selector: 'app-crud-cliente',
  templateUrl: './crud-cliente.component.html',
  styleUrls: ['./crud-cliente.component.scss']
})
export class CrudClienteComponent {

  clienteSeleccionado : Cliente = new Cliente;
  nacimiento : Date = new Date;
  constructor(private log : LogService, private api : ApiService){
    log.Set(localStorage.getItem("token") as string,"Administrador");
  }

  ClienteSeleccionado(cliente:Cliente){
    this.clienteSeleccionado = cliente;
  }

  DeseleccionarCliente(){
    this.clienteSeleccionado = new Cliente;
  }

  CambiarFecha(){
    this.clienteSeleccionado.fechaNacimiento = this.nacimiento;
  }

}
