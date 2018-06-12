import { Injectable, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CookieService } from 'ng2-cookies';

import { RestClientService } from './../services/rest-client.service';

import { ApiConfig } from '../models/api-config.interface';
import { Login, NovaSenha } from './../models/auth.interface';

@Injectable()
export class AuthService {

  private _config: ApiConfig = {
    Debug: false,
    Prefixo: '/usuarios',
    UrlDebug: '',
  };

  // tslint:disable-next-line:member-ordering
  private static _autenticado = false;
  // tslint:disable-next-line:member-ordering
  private static _expires: string;
  // tslint:disable-next-line:member-ordering
  private static _usuarioEmail: string;

  constructor(
    private _cookie: CookieService,
    private _rota: Router,
    private _rest: RestClientService
  ) {
    AuthService._expires = this._cookie.get('expiration');

    if (new Date() >= new Date(AuthService._expires) || !AuthService._expires) {
      this.usuarioNaoAutenticado();
    }

    if (this._cookie.check('accessToken')) {
      AuthService._autenticado = true;
    }
  }

  entrar(login: Login) {
    this._cookie.deleteAll();
    return this.setToken(login);
  }

  autenticacao(autenticado: boolean, data: any, senha_padrao: boolean) {
    if (autenticado) {
      this._cookie.set('authenticated', data.authenticated);
      this._cookie.set('created', data.created);
      this._cookie.set('expiration', data.expiration);
      this._cookie.set('accessToken', data.accessToken);
      this._cookie.set('message', data.message);

      AuthService._autenticado = autenticado;

      if (!senha_padrao) {
        this.atualizarRota();
      }
    } else {
      AuthService._autenticado = autenticado;
    }
  }

  atualizarRota() {
    this._rota.navigate(['/palpites']);
  }

  setToken(login: Login) {
    const segmento = '/login';

    const params = {
      email: login.email,
      senha: login.senha
    };

    return this._rest.post(this._config, segmento, params);
  }

  userUpdate(newPassword: NovaSenha) {
    const segmento = '/atualizarSenha';

    const params = {
      email: AuthService._usuarioEmail,
      novaSenha: newPassword.novaSenha,
      novaSenhaConfirmacao: newPassword.novaSenhaConfirmacao
    };

    return this._rest.post(this._config, segmento, params);
  }

  private usuarioNaoAutenticado() {
    this._cookie.deleteAll();
    AuthService._autenticado = false;
  }

  usuarioAutenticado() {
    if (new Date() >= new Date(AuthService._expires)) {
      this.usuarioNaoAutenticado();
    }
    return AuthService._autenticado;
  }

  sair() {
    this.usuarioNaoAutenticado();
    this._rota.navigate(['/login']);
  }

  get usuarioEmail() {
    return AuthService._usuarioEmail;
  }

  atualizarUsuario(email: string) {
    AuthService._usuarioEmail = email;
  }

}
