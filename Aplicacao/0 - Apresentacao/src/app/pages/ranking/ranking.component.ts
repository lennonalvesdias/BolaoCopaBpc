import { Component, OnInit, OnDestroy } from '@angular/core';
import { RestClientService } from '../../shared/services/rest-client.service';
import { ApiConfig } from '../../shared/models/api-config.interface';
import { timer } from 'rxjs/observable/timer';
import { switchMap } from 'rxjs/operators';
import { Subscription } from 'rxjs';

declare var md5;

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss']
})
export class RankingComponent implements OnInit, OnDestroy {

  private _resultadosSubscription: Subscription;
  private _intervalo = timer(0, 1800000);

  private _configRanking: ApiConfig = {
    Debug: false,
    Prefixo: '/ranking',
    UrlDebug: '',
  };

  private _resultados: any;

  constructor(
    private _rest: RestClientService
  ) {
  }

  ngOnInit() {
    this.refreshRanking();
  }

  get resultados() {
    return this._resultados;
  }

  private refreshRanking() {
    const resultado = this._intervalo.pipe(switchMap(() => this._rest.get(this._configRanking)));
    this._resultadosSubscription = resultado.subscribe(resultados => this._resultados = resultados.data);
  }

  getImagemUsuario(email) {
    return `https://www.gravatar.com/avatar/${md5(email)}?s=250&d=404`;
  }

  ngOnDestroy() {
    this._resultadosSubscription.unsubscribe();
  }

  strToArray(nome: string) {
    return nome.split(' ');
  }
}
