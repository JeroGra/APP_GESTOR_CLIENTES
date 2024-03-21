import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Administrador } from '../modelos/Administrador';
import { Cliente } from '../modelos/Cliente';

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

  
  public async iniciarSesionCliente(correo : string, dni : Number) : Promise<any> {

    let cli : Cliente = new Cliente();
    cli.correo = correo;
    cli.dni = dni;

    return await this.htpp.post<any>(`${this.urlApi}cliente/ingresar`,cli);
  }

  public listarClientes(miToken : string) : Observable<any> {

    const token = `Bearer ${miToken}`;
    const header = new HttpHeaders ({
      Authorization:token
    }); 

    return this.htpp.get<any>(`${this.urlApi}administrador/clientes`,{headers:header});
  }

}
