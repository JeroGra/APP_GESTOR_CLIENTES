import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeorefService {

  private urlProvincias :string = "https://apis.datos.gob.ar/georef/api/provincias";

  constructor(private htpp : HttpClient) { }

  public TraerProvincias() : Observable<any> {

    return this.htpp.get<any>(this.urlProvincias);

  }


}
