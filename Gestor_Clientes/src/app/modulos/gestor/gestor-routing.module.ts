import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GestorComponent } from './gestor.component';
import { CrudClienteComponent } from 'src/app/componentes/crud-cliente/crud-cliente.component';
import { ListaClientesComponent } from 'src/app/componentes/lista-clientes/lista-clientes.component';
import { ClientesEliminadosComponent } from 'src/app/componentes/clientes-eliminados/clientes-eliminados.component';
import { activateGuardRolAdmin } from 'src/app/servicios/guard.guard';

const routes: Routes = [{ path: '', component: GestorComponent, 
children : 
[
  {path : 'crud',component:CrudClienteComponent},
  {path : 'clientes',component:ListaClientesComponent, canActivate: [activateGuardRolAdmin]},
  {path : 'eliminados',component:ClientesEliminadosComponent , canActivate: [activateGuardRolAdmin]},

] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GestorRoutingModule { }
