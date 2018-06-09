import { Router } from '@angular/router';
// import { CookieService } from 'ng2-cookies';
import { Injectable } from '@angular/core';

// import { User } from './../models/user.interface';
import { ApiConfig } from '../models/api-config.interface';
import { RestClientService } from '../services/rest-client.service';

@Injectable()
export class PermissionsService {
  // public static _usuario: User;
  private _config: ApiConfig;

  constructor(
    private _rest: RestClientService,
    // private _cookies: CookieService,
    private _router: Router
  ) {
    // this._config = {
    //   Debug: false,
    //   Prefixo: '/GerenciamentoUsuarios',
    //   UrlDebug: ''
    // };

    // this.loadUser();
  }

  async loadUser(): Promise<any> {
    // if (!this._cookies.get('UserId')) {
    //   return;
    // }

    // const params = {
    //   Login: this._cookies.get('UserId')
    // }

    // const segmento = '/Usuario/Buscar';
    // const response = await this._rest.get(this._config, segmento, params).toPromise();
    // PermissionsService._usuario = response;
  }

  async validaPermissao(codigo: number, navigate: Boolean = false) {
    // if (!codigo) {
    //   toastr.error('Favor inserir um código válido.');
    //   return false;
    // }

    // if (!PermissionsService._usuario) {
    //   await this.loadUser();
    // }

    // if (PermissionsService._usuario.Admin) return true;

    // const permissoes: any = PermissionsService._usuario.Permissoes;
    // const validaPermissao = permissoes.filter(p => p.FuncionalidadeCodigo === codigo);

    // if (!validaPermissao || !validaPermissao[0]) {
    //   if (navigate) {
    //     this._router.navigate(['/403']);
    //   } else {
    //     return validaPermissao[0] === null;
    //   }
    // }
  }

  async getUsuario() {
    // if (!PermissionsService._usuario) await this.loadUser();
    // return PermissionsService._usuario;
  }

  async atualizarUsuario() {
    // await this.loadUser();
  }
}
