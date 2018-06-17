import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutDefault } from '../layouts/default/default.component';
import { AuthGuard } from '../shared/auth/auth.guard';

const routes: Routes = [
  {
    path: '', redirectTo: 'palpites', pathMatch: 'full'
  },

  {
    path: '',
    component: LayoutDefault,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'palpites', loadChildren: './palpites/palpites.module#PalpitesModule'
      },
      {
        path: 'resultados', loadChildren: './resultados/resultados.module#ResultadosModule'
      },
      {
        path: 'auditoria', loadChildren: './auditoria/auditoria.module#AuditoriaModule'
      },
      {
        path: 'aovivo', loadChildren: './aovivo/aovivo.module#AovivoModule'
      }
    ]
  },

  {
    path: 'login', loadChildren: './login/login.module#LoginModule'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
