import { Component } from '@angular/core';
import { Cliente } from 'src/app/modelos/Cliente';
import { ApiService } from 'src/app/servicios/api.service';
import { LogService } from 'src/app/servicios/log.service';

@Component({
  selector: 'app-clientes-eliminados',
  templateUrl: './clientes-eliminados.component.html',
  styleUrls: ['./clientes-eliminados.component.scss']
})
export class ClientesEliminadosComponent {

  clienteSeleccionado : Cliente = new Cliente;
  nacimiento : Date = new Date;
  privincias : Array<any> = [];
  arrayClientes : Array<Cliente> = [];

  constructor(private log : LogService, private api : ApiService){
    log.Set(localStorage.getItem("token") as string,"Administrador");
    this.TraerClientesEliminaods();
  }

  TraerClientesEliminaods(){
    try
    {
      this.api.listarClientesEliminados(localStorage.getItem("token") as string).subscribe((data:Cliente[]) => { this.arrayClientes = data});

    }catch(e)
    {

    }
  }

  ClienteSeleccionado(cliente:Cliente){
    this.clienteSeleccionado = cliente;
  }


}
