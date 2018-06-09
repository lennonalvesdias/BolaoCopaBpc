import { Injectable, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import { CookieService } from 'ng2-cookies';
import { PermissionsService } from './permissions.service';

import { RestClientService } from './../services/rest-client.service';

import { ApiConfig } from '../models/api-config.interface';
import { Login } from './../models/auth.interface';

declare var toastr: any;

@Injectable()
export class AuthService {

  // private _config: ApiConfig = {
  //   Debug: false,
  //   Prefixo: '/GerenciamentoUsuarios',
  //   UrlDebug: '',
  // };

  // tslint:disable-next-line:member-ordering
  private static _autenticado = false;
  // tslint:disable-next-line:member-ordering
  private static _expires: string;
  private _returnUrl: string;

  constructor(
    // private _cookie: CookieService,
    private _rota: Router,
    private _rotaAtiva: ActivatedRoute,
    private _rest: RestClientService,
    private _permissions: PermissionsService
  ) {
    // AuthService._expires = this._cookie.get('Expires');

    // if (new Date() >= new Date(AuthService._expires) || !AuthService._expires) {
    //   this.usuarioNaoAutenticado();
    // }

    // if (this._cookie.check('AccessToken')) {
    //   AuthService._autenticado = true;
    // }

    // this._returnUrl = this._rotaAtiva.queryParams['_value'].returnUrl;
  }

  entrar(login: Login) {
    // this._cookie.deleteAll();
    // return this.setToken(login);
  }

  autenticacao(autenticado, data) {
    // if (autenticado) {
    //   this._cookie.set('AccessToken', data.access_token);
    //   this._cookie.set('TokenType', data.token_type);
    //   this._cookie.set('ExpiresIn', data.expires_in);
    //   this._cookie.set('UserId', data.user_id);
    //   this._cookie.set('Issued', data['.issued']);
    //   this._cookie.set('Expires', data['.expires']);

    //   AuthService._autenticado = autenticado;
    //   this._permissions.atualizarUsuario();

    //   if (this._returnUrl) {
    //     this._rota.navigate([Helpers.validReturnUrl(this._returnUrl)]);
    //   } else {
    //     this._rota.navigate(['/dashboard']);
    //   }
    // } else {
    //   AuthService._autenticado = autenticado;
    // }
  }

  setToken(login: Login) {
    // const segmento = '/Usuario/Login';

    // const params = {
    //   Username: login.usuario,
    //   Password: login.senha
    // };

    // return this._rest.get(this._config, segmento, params);
  }

  private usuarioNaoAutenticado() {
    // this._cookie.deleteAll();
    // AuthService._autenticado = false;
  }

  usuarioAutenticado() {
    // if (new Date() >= new Date(AuthService._expires)) {
    //   this.usuarioNaoAutenticado();
    // }
    // return AuthService._autenticado;
  }

  sair() {
    // this.usuarioNaoAutenticado();
    // this._rota.navigate(['/login']);
  }

}
