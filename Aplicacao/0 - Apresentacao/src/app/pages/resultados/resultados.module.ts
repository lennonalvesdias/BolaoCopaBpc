import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ResultadosRoutingModule } from './resultados-routing.module';
import { ResultadosComponent } from './resultados.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ResultadosRoutingModule
  ],
  declarations: [ResultadosComponent]
})
export class ResultadosModule { }
