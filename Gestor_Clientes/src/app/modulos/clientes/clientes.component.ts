import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LogService } from 'src/app/servicios/log.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent {

  constructor(private route : Router, private log : LogService){
    this.route.navigateByUrl('clientes/perfil');
    log.Set(localStorage.getItem("token") as string,"Cliente");
  }

}
