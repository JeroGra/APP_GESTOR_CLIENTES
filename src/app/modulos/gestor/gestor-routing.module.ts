import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GestorComponent } from './gestor.component';
import { CrudClienteComponent } from 'src/app/componentes/crud-cliente/crud-cliente.component';
import { ListaClientesComponent } from 'src/app/componentes/lista-clientes/lista-clientes.component';
import { PerfilComponent } from 'src/app/componentes/perfil/perfil.component';

const routes: Routes = [{ path: '', component: GestorComponent, 
children : 
[
  
  {path : 'crud',component:CrudClienteComponent},
  {path : 'clientes',component:ListaClientesComponent},
  {path : 'perfil',component:PerfilComponent}
] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GestorRoutingModule { }
