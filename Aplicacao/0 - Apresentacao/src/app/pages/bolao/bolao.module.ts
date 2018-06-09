import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BolaoRoutingModule } from './bolao-routing.module';
import { BolaoComponent } from './bolao.component';

@NgModule({
  imports: [
    CommonModule,
    BolaoRoutingModule
  ],
  declarations: [BolaoComponent]
})
export class BolaoModule { }
