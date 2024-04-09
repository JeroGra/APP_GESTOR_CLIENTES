import { Injectable } from '@angular/core';
import { Administrador } from '../modelos/Administrador';
import { Cliente } from '../modelos/Cliente';
import { ApiService } from './api.service';
import { jwtDecode } from 'jwt-decode';
import { Usuario } from '../modelos/Usuario';
import { Direccion } from '../modelos/Direccion';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  private status = false;
  private user : Usuario = new Usuario;
  private token : string = "";
  private rol : string = "";
  

  constructor(private api : ApiService) { }

  public Set(token:string,rol:"Administrador"|"Cliente"){

    localStorage.setItem("token",token);
    let tokenDecode : any = jwtDecode(token);

    this.user.correo = tokenDecode.Correo;
    this.user.id = tokenDecode.ID;
    this.token = token;
    this.rol = rol;
    this.status = true;

  }

  public Get(){

    return { status:this.status, userId:this.user.id, userMail:this.user.correo, user:this.user, token:this.token, rol:this.rol };

  }

}
