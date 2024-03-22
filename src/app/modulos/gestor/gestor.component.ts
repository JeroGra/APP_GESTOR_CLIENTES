import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gestor',
  templateUrl: './gestor.component.html',
  styleUrls: ['./gestor.component.scss']
})
export class GestorComponent {

  constructor(private route : Router){
    this.route.navigateByUrl('gestor/crud');
  }

}
