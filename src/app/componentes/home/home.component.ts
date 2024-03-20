import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/servicios/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  data : boolean = false;

  constructor(private api : ApiService, private route : Router){};

  ngOnInit(){

    this.apiConect();

  }

  apiConect(){

    this.api.checkSqlConection().subscribe( (data:any) => {

      this.data = data ;
      console.log(data)
      this.checkConection();
      
    })
  }

  checkConection(){
    if(this.data){ this.route.navigateByUrl('logIn')};
  }

}
