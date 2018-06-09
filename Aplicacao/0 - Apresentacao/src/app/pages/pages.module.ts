import { RestClientService } from './../shared/services/rest-client.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';

import { AuthGuard } from '../shared/auth/auth.guard';
import { AuthService } from '../shared/auth/auth.service';
import { PermissionsService } from './../shared/auth/permissions.service';
import { GenericService } from './../shared/services/generic.service';

@NgModule({
  imports: [
    CommonModule,
    PagesRoutingModule
  ],
  declarations: [],
  providers:  [
    AuthGuard,
    AuthService,

    RestClientService,
    PermissionsService,

    GenericService
  ]
})
export class PagesModule { }
