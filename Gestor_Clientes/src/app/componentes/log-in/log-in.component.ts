import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/servicios/api.service';
import { LogService } from 'src/app/servicios/log.service';
import Swal from 'sweetalert2';

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
  public formCliente : FormGroup;

  constructor(private fb : FormBuilder, private api : ApiService, private log :LogService, private route : Router){

    this.formAdministrador = this.fb.group({
      correo : ['',[

      ]],
      clave : ['',[

      ]],
    });

    this.formCliente = this.fb.group({
      correo : ['',[

      ]],
      dni : ['',[

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

    //Hardcore
    this.correo = "anaT@gmail.com";
    this.dni = 22222222;

  }

  atras(){

    if(this.usuario_cliente){this.select_usuarios = true;  this.usuario_cliente = false;}
    else{
      if(this.usuario_administrador){this.select_usuarios = true;  this.usuario_administrador = false;}}

  }

  logIn(){

      if(this.usuario_administrador){
          this.api.iniciarSesionAdministrador(this.correo,this.clave).subscribe((response:any) => {

            if(response.ok){

              this.log.Set(response.data,"Administrador"), this.route.navigateByUrl("/gestor") 
  
              Swal.fire({
               text: response.mensaje,
               showConfirmButton: false,
               timer: 1000,
               toast: true,
               position: 'top',
               icon:'success',
             });

            }else{

              Swal.fire({
                text: response.mensaje,
                showConfirmButton: false,
                timer: 1000,
                toast: true,
                position: 'top',
                icon:'error',
              });

            }
          });
      }else{
        if(this.usuario_cliente){
          this.api.iniciarSesionCliente(this.correo,this.dni).subscribe((response:any) => {

            if(response.ok){

              this.log.Set(response.data,"Cliente"),this.route.navigateByUrl("/clientes") 
  
              Swal.fire({
               text: response.mensaje,
               showConfirmButton: false,
               timer: 1000,
               toast: true,
               position: 'top',
               icon:'success',
             });

            }else{

              Swal.fire({
                text: response.mensaje,
                showConfirmButton: false,
                timer: 1000,
                toast: true,
                position: 'top',
                icon:'error',
              });

            }
          });
        }
      }

  }


}
