import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { PalpitesRoutingModule } from './palpites-routing.module';
import { PalpitesComponent } from './palpites.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PalpitesRoutingModule
  ],
  declarations: [PalpitesComponent]
})
export class PalpitesModule { }
