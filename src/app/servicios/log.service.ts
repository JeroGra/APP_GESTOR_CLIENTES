import { Injectable } from '@angular/core';
import { Administrador } from '../modelos/Administrador';
import { Cliente } from '../modelos/Cliente';
import { ApiService } from './api.service';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  private status = false;
  private user : Administrador | Cliente | null = null;
  private token : string = "";
  private rol : string = "";
    
  constructor(private api : ApiService) { }

  public Set(token:string,rol:"Administrador"|"Cliente"){

    localStorage.setItem("token",token);

    let tokenDecode : any = jwtDecode(token);
    let tokenData : any = tokenDecode.data;

    //funcion donde llamo al usuario segun el id
    
    this.token = token;
    this.rol = rol;
    this.status = true;
  }

  public Get(){

    return { status:this.status, user:this.user, token:this.token, rol:this.rol }

  }

}
