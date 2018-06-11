
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Injectable } from '@angular/core';

import { CookieService } from 'ng2-cookies';

// tslint:disable-next-line:import-blacklist
import 'rxjs/Rx';

import { ApiConfig } from '../models/api-config.interface';
import { API_BASE_URL } from '../shared.constants';

@Injectable({
  providedIn: 'root'
})
export class RestClientService {

  private _headers = new Headers();
  private _baseUrl: string;
  constructor(
    private _http: Http,
    private _cookieService: CookieService
  ) {
    this._headers.set('Content-Type', 'application/json');
    this._baseUrl = API_BASE_URL;
  }

  private montarRequisicao(config: ApiConfig, segmento: string, headers: Map<string, string>, autentication: boolean) {
    if (headers != null) {
      this.gerarHeaders(headers);
    }

    if (autentication === true) {
      this._headers.set('Authorization', this.autenticacao);
    }

    if (config.Debug) {
      return config.UrlDebug + segmento;
    }

    return this._baseUrl + config.Prefixo + segmento;
  }

  private gerarHeaders(headers: Map<string, string>) {
    headers.forEach((value: string, key: string) => {
      this._headers.set(key, value);
    });
  }

  get(config: ApiConfig, segmento: string = null, params = null, headers: Map<string, string> = null, autentication: boolean = true) {
    const url = this.montarRequisicao(config, segmento, headers, autentication);
    return this._http.get(url, { headers: this._headers, params: params }).pipe(
      map((res: Response) => res.json()));
  }

  // tslint:disable-next-line:max-line-length
  post(config: ApiConfig, segmento: string = null, body: any, params = null, headers: Map<string, string> = null, autentication: boolean = true) {
    const url = this.montarRequisicao(config, segmento, headers, autentication);
    return this._http.post(url, JSON.stringify(body), { headers: this._headers, params: params }).pipe(
      map((res: Response) => res.json()));
  }

  // tslint:disable-next-line:max-line-length
  put(config: ApiConfig, segmento: string = null, body: any, params = null, headers: Map<string, string> = null, autentication: boolean = true) {
    const url = this.montarRequisicao(config, segmento, headers, autentication);
    return this._http.put(url, JSON.stringify(body), { headers: this._headers, params: params }).pipe(
      map((res: Response) => res.json()));
  }

  // tslint:disable-next-line:max-line-length
  patch(config: ApiConfig, segmento: string = null, body: any, params = null, headers: Map<string, string> = null, autentication: boolean = true) {
    const url = this.montarRequisicao(config, segmento, headers, autentication);
    return this._http.patch(url, JSON.stringify(body), { headers: this._headers, params: params }).pipe(
      map((res: Response) => res.json()));
  }

  delete(config: ApiConfig, segmento: string = null, params = null, headers: Map<string, string> = null, autentication: boolean = true) {
    const url = this.montarRequisicao(config, segmento, headers, autentication);
    return this._http.delete(url, { headers: this._headers, params: params }).pipe(
      map((res: Response) => res.text() ? res.json() : {}));
  }

  openUrl(config: ApiConfig, segmento: string = null, params = null, headers: Map<string, string> = null, autentication: boolean = true) {
    const url = this.montarRequisicao(config, segmento, headers, autentication);
    window.open(url, '_blank');
  }

  private get autenticacao() {
    return `Bearer ${this._cookieService.get('accessToken')}`;
  }

}
