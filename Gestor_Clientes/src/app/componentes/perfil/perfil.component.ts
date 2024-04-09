import { Component } from '@angular/core';
import { Cliente } from 'src/app/modelos/Cliente';
import { Direccion } from 'src/app/modelos/Direccion';
import { Usuario } from 'src/app/modelos/Usuario';
import { ApiService } from 'src/app/servicios/api.service';
import { LogService } from 'src/app/servicios/log.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent {

  usuario : Usuario = new Usuario;
  direccion : Direccion = new Direccion;
  userId : Number = 0;

  constructor(private log : LogService, private api : ApiService){
    log.Set(localStorage.getItem("token") as string,"Cliente");
    this.userId = log.Get().userId;
    this.TraerUsuario();
  }

  TraerUsuario(){
    this.api.ObtenerClienteId(this.log.Get().token,this.userId).subscribe((data:Cliente)=>{

      this.usuario = new Usuario(data.id,data.nombre,data.apellido,data.fechaNacimiento,data.dni,data.correo);
      this.direccion = data.direccion;

    });
  }

}
