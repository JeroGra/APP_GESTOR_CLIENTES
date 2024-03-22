import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GestorRoutingModule } from './gestor-routing.module';
import { GestorComponent } from './gestor.component';


@NgModule({
  declarations: [
    GestorComponent
  ],
  imports: [
    CommonModule,
    GestorRoutingModule
  ]
})
export class GestorModule { }
