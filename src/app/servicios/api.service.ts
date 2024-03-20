import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = "https://localhost:7266/api/";

  constructor(private htpp : HttpClient) { }

  public checkSqlConection () : Observable<any> {

   return this.htpp.get<any>(this.urlApi + "conexion");

  }

}
