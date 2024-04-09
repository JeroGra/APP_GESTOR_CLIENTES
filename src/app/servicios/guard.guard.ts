import { CanActivateFn } from '@angular/router';
import Swal from 'sweetalert2';
import { LogService } from './log.service';
import { inject } from '@angular/core';


export const activateGuardRolAdmin: CanActivateFn = (route, state) => {
  let userRol =  inject(LogService).Get().rol

  if(userRol !== "Administrador")
  {
    Swal.fire({
      text: "No tienes los permisos para accede",
      showConfirmButton: false,
      timer: 1000,
      toast: true,
      position: 'top',
      icon:'error',
    });
  }

  return inject(LogService).Get().status && userRol === "Administrador";
};

export const activateGuardRolCliente: CanActivateFn = (route, state) => {
  let userRol =  inject(LogService).Get().rol

  if(userRol !== "Cliente")
  {
    Swal.fire({
      text: "No eres un Cliente",
      showConfirmButton: false,
      timer: 1000,
      toast: true,
      position: 'top',
      icon:'error',
    });
  }
  
  return inject(LogService).Get().status && userRol === "Cliente";
};
