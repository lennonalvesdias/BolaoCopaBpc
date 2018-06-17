import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AovivoRoutingModule } from './aovivo-routing.module';
import { AovivoComponent } from './aovivo.component';

@NgModule({
  imports: [
    CommonModule,
    AovivoRoutingModule
  ],
  declarations: [AovivoComponent]
})
export class AovivoModule { }
