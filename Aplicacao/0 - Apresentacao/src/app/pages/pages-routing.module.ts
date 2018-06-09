import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: 'figurinhas', pathMatch: 'full'
  },

  {
    path: 'figurinhas', loadChildren: './figurinhas/figurinhas.module#FigurinhasModule'
  },

  {
    path: 'bolao', loadChildren: './bolao/bolao.module#BolaoModule'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
