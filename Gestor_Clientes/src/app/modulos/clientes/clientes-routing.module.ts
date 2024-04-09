import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './clientes.component';
import { PerfilComponent } from 'src/app/componentes/perfil/perfil.component';
import { activateGuardRolCliente } from 'src/app/servicios/guard.guard';

const routes: Routes = [{ path: '', component: ClientesComponent,
children : 
[
  {path : 'perfil',component:PerfilComponent,}
  
]}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientesRoutingModule { }
