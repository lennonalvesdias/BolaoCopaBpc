import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthGuard } from './../shared/auth/auth.guard';
import { AuthService } from './../shared/auth/auth.service';

import { RestClientService } from './../shared/services/rest-client.service';
import { GenericService } from './../shared/services/generic.service';

import { PagesRoutingModule } from './pages-routing.module';

import { LayoutDefault } from './../layouts/default/default.component';

import { ComponentsModule } from './../shared/components/components.module';
import { LoginModule } from './login/login.module';
import { PalpitesModule } from './palpites/palpites.module';

@NgModule({
  imports: [
    CommonModule,
    PagesRoutingModule,
    ComponentsModule,

    LoginModule,
    PalpitesModule
  ],
  declarations: [LayoutDefault],
  providers: [
    GenericService,
    RestClientService,

    AuthService,
    AuthGuard
  ]
})
export class PagesModule { }
