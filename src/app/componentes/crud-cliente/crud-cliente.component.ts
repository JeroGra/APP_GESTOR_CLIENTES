import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/modelos/Cliente';
import { Direccion } from 'src/app/modelos/Direccion';
import { Usuario } from 'src/app/modelos/Usuario';
import { ApiService } from 'src/app/servicios/api.service';
import { GeorefService } from 'src/app/servicios/georef.service';
import { LogService } from 'src/app/servicios/log.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-crud-cliente',
  templateUrl: './crud-cliente.component.html',
  styleUrls: ['./crud-cliente.component.scss']
})
export class CrudClienteComponent {

  clienteSeleccionado : Cliente = new Cliente;
  nacimiento : Date = new Date;
  privincias : Array<any> = [];
  arrayClientes : Array<Cliente> = [];

  errorForm = true;

  errorNombre = false;
  errorApellido = false;
  errorCorreo = false;
  errorDni = false;
  errorFecha = false;
  errorProvincia = false;
  errorLocalidad = false;
  errorCalle = false;
  errorNumero = false;
  errorCodigo = false;
  errorTelefono = false;


  constructor(private log : LogService, private api : ApiService, private georef: GeorefService, private ruta : Router){
    log.Set(localStorage.getItem("token") as string,"Administrador");
    this.TraerClientes();
    georef.TraerProvincias().subscribe(data =>{
      this.privincias = data.provincias as Array<any>;
      console.log(this.privincias)
    });
  }

  TraerClientes(){
    try
    {
      this.api.listarClientes(localStorage.getItem("token") as string).subscribe((data:Cliente[]) => { this.arrayClientes = data});

    }catch(e)
    {

    }
  }

  ClienteSeleccionado(cliente:Cliente){
    this.clienteSeleccionado = cliente;
  }

  DeseleccionarCliente(){
    this.clienteSeleccionado = new Cliente;
  }

  CambiarFecha(){
    this.clienteSeleccionado.fechaNacimiento = this.nacimiento;
    this.Validar("Fecha");
  }

  ProvinciaSelect(value :string){
    this.clienteSeleccionado.direccion.provincia = value;
    this.Validar("Provincia");

    if(this.clienteSeleccionado.direccion.provincia == "Ciudad Autónoma de Buenos Aires"){
      this.clienteSeleccionado.direccion.localidad = "CABA";
    }else{ this.clienteSeleccionado.direccion.localidad = ""}

  }

  Validar(tipo : "Nombre" | "Apellido" | "Correo" | "Dni" | "Fecha" | "Provincia" | "Localidad" | "Calle" | "Numero" | "Codigo" | "Telefono"){

    switch(tipo)
    {
      case 'Nombre':
        if(this.ValidarNombre(this.clienteSeleccionado.nombre) && this.clienteSeleccionado.nombre.length >= 3 && this.clienteSeleccionado.nombre.length <= 15 ){
          this.errorNombre = false;
        }else{      
          this.errorNombre = true;
        };
        
      break;

      case 'Apellido':
        if(this.ValidarNombre(this.clienteSeleccionado.apellido) && this.clienteSeleccionado.apellido.length >= 3 && this.clienteSeleccionado.apellido.length <= 15 ){
          this.errorApellido = false;
        }else{      
          this.errorApellido = true;
        };
      break;
      case 'Correo':
        if(this.ValidarCorreo(this.clienteSeleccionado.correo)){
          this.errorCorreo = false;
        }else{      
          this.errorCorreo = true;
        };
      break;
      case 'Dni':
        if(this.ValidarNumero(this.clienteSeleccionado.dni) && this.clienteSeleccionado.dni.toString().length <= 8 &&  this.clienteSeleccionado.dni.toString().length >= 7){
          this.errorDni = false;
        }else{      
          this.errorDni = true;
        };
      break;
      case 'Fecha':
        if(this.VerificarEdad(this.clienteSeleccionado.fechaNacimiento)){
          this.errorFecha = false;
        }else{      
          this.errorFecha = true;
        };
      break;
      case 'Provincia':
        if(this.clienteSeleccionado.direccion.provincia != ""){
          this.errorProvincia = false;
        }else{
          this.errorProvincia = true;
        }
      break;
      case 'Localidad':
        if(this.ValidarNombreConEspacios(this.clienteSeleccionado.direccion.localidad) && this.clienteSeleccionado.direccion.localidad.length >= 4 && this.clienteSeleccionado.direccion.localidad.length <= 20 ){
          this.errorLocalidad = false;
        }else{
          this.errorLocalidad = true;
        }
      break;
      case 'Calle':
        if(this.ValidarNombreConEspacios(this.clienteSeleccionado.direccion.calle) && this.clienteSeleccionado.direccion.calle.length >= 5 && this.clienteSeleccionado.direccion.calle.length <= 20 ){
          this.errorCalle = false;
        }else{
          this.errorCalle = true;
        }
      break;
      case 'Numero':
        if(this.ValidarNumero(this.clienteSeleccionado.direccion.numero) && this.clienteSeleccionado.direccion.numero.toString().length >= 1 &&  this.clienteSeleccionado.direccion.numero.toString().length <= 4){
          this.errorNumero = false;
        }else{      
          this.errorNumero = true;
        };
      break;
      case 'Codigo':
        if(this.ValidarNumero(this.clienteSeleccionado.direccion.codigoPostal) && this.clienteSeleccionado.direccion.codigoPostal.toString().length == 4 ){
          this.errorCodigo = false;
        }else{      
          this.errorCodigo = true;
        };
      break;
      case 'Telefono':
        if(this.ValidarNumero(this.clienteSeleccionado.direccion.numeroTelefono) && this.clienteSeleccionado.direccion.numeroTelefono.toString().length >= 9 && this.clienteSeleccionado.direccion.numeroTelefono.toString().length <= 12 ){
          this.errorTelefono = false;
        }else{      
          this.errorTelefono = true;
        };
      break;
    }

    this.ErrorForm();

  }

  ValidarNombre(string:String) : boolean  {

    // Expresión regular para verificar si la cadena contiene solo caracteres alfabéticos
    const expresionRegular = /^[a-zA-Z]+$/;
    
    // Verificar si la cadena coincide con la expresión regular
    return expresionRegular.test(string as string);

  } 

  ValidarNumero(valor : any) : boolean{

    return !isNaN(parseFloat(valor)) && isFinite(valor);

  }

   ValidarNombreConEspacios(cadena: String): boolean {
    // Expresión regular que verifica si la cadena contiene solo caracteres alfabéticos y espacios
    const regex: RegExp = /^[a-zA-Z\s]+$/;

    // Verificamos si la cadena cumple con la expresión regular
    return regex.test(cadena as string);
}

   ValidarCorreo(correo: String): boolean {
    // Verificar la longitud de la cadena
    if (correo.length < 10 || correo.length > 30) {
        return false;
    }
    
    // Verificar si contiene al menos un símbolo "@"
    if (correo.indexOf("@") === -1) {
        return false;
    }
    
    // Cumple con todos los requisitos
    return true;
}

  VerificarEdad(fechaString: Date): boolean {
    // Convertimos el string a un objeto de tipo Date
    const fecha: Date = new Date(fechaString);

    // Verificamos si la conversión fue exitosa y si la fecha es válida
    if (isNaN(fecha.getTime())) {
        throw new Error('La fecha proporcionada no es válida.');
    }

    // Obtenemos la fecha actual
    const fechaActual: Date = new Date();

    // Calculamos la diferencia de años entre la fecha actual y la fecha proporcionada
    const diferenciaAnios: number = fechaActual.getFullYear() - fecha.getFullYear();

    // Verificamos si la diferencia es igual o mayor a 18 años
    if (diferenciaAnios >= 18) {
        return true;
    } else {
        return false;
    }
}

ErrorForm(){
  if(this.errorNombre || this.errorApellido || this.errorCorreo || this.errorDni || this.errorFecha || this.errorProvincia || this.errorLocalidad || this.errorCalle || this.errorNumero || this.errorCodigo || this.errorTelefono){
    this.errorForm = true;
  }
  else{
    this.errorForm = false; 
  }
}

AgregarCliente(){

  this.Validar('Nombre');
  this.Validar('Apellido');
  this.Validar('Correo');
  this.Validar('Dni');
  this.Validar('Fecha');
  this.Validar('Localidad');
  this.Validar('Provincia');
  this.Validar('Calle');
  this.Validar('Numero');
  this.Validar('Codigo');
  this.Validar('Telefono');


  if(!this.errorForm){


    let usuario = new Usuario(0,this.clienteSeleccionado.nombre,this.clienteSeleccionado.apellido,this.clienteSeleccionado.fechaNacimiento,this.clienteSeleccionado.dni,this.clienteSeleccionado.correo);
    let direccion = new Direccion(0,this.clienteSeleccionado.direccion.provincia,this.clienteSeleccionado.direccion.localidad,this.clienteSeleccionado.direccion.calle,this.clienteSeleccionado.direccion.numero,this.clienteSeleccionado.direccion.codigoPostal,this.clienteSeleccionado.direccion.numeroTelefono);

    this.api.InsertarCliente(this.log.Get().token,usuario,direccion).subscribe((data:any)=>{
     
      if(data.ok){
        Swal.fire({
          position: "top",
          icon: "success",
          title: data.mensaje,
          showConfirmButton: false,
          timer: 1500
        });

        this.TraerClientes();

      }else{
        Swal.fire({
          position: "top",
          icon: "error",
          title: data.mensaje,
          showConfirmButton: false,
          timer: 1500
        });
      }

    });



  }else{
    Swal.fire({
      position: "top",
      icon: "error",
      title: "ERROR! Faltan datos necesarios",
      showConfirmButton: false,
      timer: 1500
      });
  }

}


ModificarCliente(){

  this.Validar('Nombre');
  this.Validar('Apellido');
  this.Validar('Correo');
  this.Validar('Dni');
  this.Validar('Fecha');
  this.Validar('Localidad');
  this.Validar('Provincia');
  this.Validar('Calle');
  this.Validar('Numero');
  this.Validar('Codigo');
  this.Validar('Telefono');


  if(!this.errorForm){

    let usuario = new Usuario(this.clienteSeleccionado.id,this.clienteSeleccionado.nombre,this.clienteSeleccionado.apellido,this.clienteSeleccionado.fechaNacimiento,this.clienteSeleccionado.dni,this.clienteSeleccionado.correo);
    let direccion = new Direccion(this.clienteSeleccionado.direccion.id,this.clienteSeleccionado.direccion.provincia,this.clienteSeleccionado.direccion.localidad,this.clienteSeleccionado.direccion.calle,this.clienteSeleccionado.direccion.numero,this.clienteSeleccionado.direccion.codigoPostal,this.clienteSeleccionado.direccion.numeroTelefono);


    this.api.ModificarCliente(this.log.Get().token,usuario,direccion).subscribe((data:any)=>{
     
      if(data.ok){
        Swal.fire({
          position: "top",
          icon: "success",
          title: data.mensaje,
          showConfirmButton: false,
          timer: 1500
        });
      }else{
        Swal.fire({
          position: "top",
          icon: "error",
          title: data.mensaje,
          showConfirmButton: false,
          timer: 1500
        });

        console.log(data.error);

      }

    });
  }else{
    Swal.fire({
      position: "top",
      icon: "error",
      title: "ERROR! Faltan datos necesarios",
      showConfirmButton: false,
      timer: 1500
      });
  }
}



EliminarCliente(){

  Swal.fire({
    title: "Estas Seguro?",
    html: "<p> Se eliminara a <strong>" + this.clienteSeleccionado.nombre + " " + this.clienteSeleccionado.apellido + ", DNI: " + this.clienteSeleccionado.dni +"</strong></p>" ,
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3fab33",
    cancelButtonColor: "#c93c3c",
    confirmButtonText: "Si, Eliminar!"
  }).then((result) => {
    if (result.isConfirmed) {

      this.api.EliminarCliente(this.log.Get().token,this.clienteSeleccionado.id).subscribe((data:any)=>{

        if(data.ok){

          Swal.fire({
            title: "Eliminado!",
            html: "<p>"+data.mensaje+"</p>",
            icon: "success"
          });

          this.TraerClientes();
          
        }else{

          Swal.fire({
            title: "ERROR!",
            html: "<p>"+ data.mensaje +"</p>",
            icon: "error"
          });

        }
      });
    }
  });

}
  

}
