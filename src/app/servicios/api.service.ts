import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Administrador } from '../modelos/Administrador';
import { Cliente } from '../modelos/Cliente';
import { Usuario } from '../modelos/Usuario';
import { Direccion } from '../modelos/Direccion';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = "https://localhost:7266/api/";

  constructor(private htpp : HttpClient) { }

  public checkSqlConection () : Observable<any> {

   return this.htpp.get<any>(this.urlApi + "conexion");

  }

  public iniciarSesionAdministrador(correo : string, clave : String) : Observable<any> {

    let adm : Administrador = new Administrador();
    adm.correo = correo;
    adm.clave = clave;

    return this.htpp.post<any>(`${this.urlApi}administrador/ingresar`,adm);

  }

  
  public iniciarSesionCliente(correo : string, dni : Number) : Observable<any> {

    let cli : Cliente = new Cliente();
    cli.correo = correo;
    cli.dni = dni;

    return this.htpp.post<any>(`${this.urlApi}cliente/ingresar`,cli);
  }

  public listarClientes(miToken : string) : Observable<any> {

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    }); 

    return this.htpp.get<any>(`${this.urlApi}administrador/clientes`,{headers:header});
  }

  public listarClientesEliminados(miToken : string) : Observable<any> {

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    }); 

    return this.htpp.get<any>(`${this.urlApi}administrador/cliente/eliminados`,{headers:header});
  }

  public InsertarCliente(miToken : string, usuario : Usuario, direccion :Direccion): Observable<any> {

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    });
    
    let resquest : any = {
      usuario:usuario,
      direccion:direccion
    }

    return this.htpp.post<any>(`${this.urlApi}administrador/cliente`,resquest,{headers:header});
  }

  
  public ModificarCliente(miToken : string, usuario : Usuario, direccion :Direccion): Observable<any> {

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    });
    
    let resquest : any = {
      usuario:usuario,
      direccion:direccion
    }

    return this.htpp.post<any>(`${this.urlApi}administrador/cliente/modificar`,resquest,{headers:header});
  }

  public EliminarCliente(miToken : string, id: Number){

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    });
    
    return this.htpp.delete<any>(`${this.urlApi}administrador/cliente/`+id,{headers:header});
  }

  public ObtenerClienteId(miToken : string, id: Number){

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    });
    
    return this.htpp.get<any>(`${this.urlApi}administrador/cliente/`+id,{headers:header});
  }

}
