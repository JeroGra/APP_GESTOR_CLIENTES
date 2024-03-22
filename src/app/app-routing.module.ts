import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './componentes/home/home.component';
import { LogInComponent } from './componentes/log-in/log-in.component';
import { ErrorComponent } from './componentes/error/error.component';

const routes: Routes = 
[
  { path:'', component:HomeComponent },
  { path:'logIn', component:LogInComponent },
  { path: 'gestor', loadChildren: () => import('./modulos/gestor/gestor.module').then(m => m.GestorModule) },
  { path:'*',component:ErrorComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
