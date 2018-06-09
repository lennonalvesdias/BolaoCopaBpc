import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BolaoComponent } from './bolao.component';

const routes: Routes = [
  {
    path: '', component: BolaoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BolaoRoutingModule { }
