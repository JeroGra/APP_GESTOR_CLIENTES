import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LogService } from 'src/app/servicios/log.service';

@Component({
  selector: 'app-gestor',
  templateUrl: './gestor.component.html',
  styleUrls: ['./gestor.component.scss']
})
export class GestorComponent {

  constructor(private route : Router,private log : LogService){
    this.route.navigateByUrl('gestor/crud');
    log.Set(localStorage.getItem("token") as string,"Administrador");
  }

}
