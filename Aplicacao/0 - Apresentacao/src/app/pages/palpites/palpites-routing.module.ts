import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PalpitesComponent } from './palpites.component';

const routes: Routes = [
  {
    path: '', component: PalpitesComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PalpitesRoutingModule { }
