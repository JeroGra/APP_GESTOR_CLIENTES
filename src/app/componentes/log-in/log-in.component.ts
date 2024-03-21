import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from 'src/app/servicios/api.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent {

  select_usuarios = true;
  usuario_administrador = false;
  usuario_cliente = false;

  correo : string = "";
  clave : string = "";
  dni : Number = 0;

  public formAdministrador : FormGroup;

  constructor(private fb : FormBuilder, private api : ApiService){

    this.formAdministrador = this.fb.group({
      correo : ['',[

      ]],
      clave : ['',[

      ]],
    })

  }

  selectAdministrador(){

    this.usuario_administrador = true;
    this.select_usuarios = false;

    //Hardcore
    this.correo = "cxs0@gmail.com";
    this.clave = "cxsadm123";

  }

  selectCliente(){

    this.usuario_cliente = true;
    this.select_usuarios = false;

  }

  atras(){

    if(this.usuario_cliente){this.select_usuarios = true;  this.usuario_cliente = false;}
    else{
      if(this.usuario_administrador){this.select_usuarios = true;  this.usuario_administrador = false;}}

  }

  logIn(){

    if(this.usuario_administrador){
      this.api.iniciarSesionAdministrador(this.correo,this.clave).subscribe((response:any) => { localStorage.setItem("token",response.data) });
    }else{
      if(this.usuario_cliente){

      }
    }

  }

}
