import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiConfig } from '../../shared/models/api-config.interface';
import { RestClientService } from '../../shared/services/rest-client.service';
import { timer } from 'rxjs/observable/timer';
import { switchMap } from 'rxjs/operators';
import { Subscription } from 'rxjs';

declare var md5;

@Component({
  selector: 'app-aovivo',
  templateUrl: './aovivo.component.html',
  styleUrls: ['./aovivo.component.scss']
})
export class AovivoComponent implements OnInit, OnDestroy {

  private _resultadosSubscription: Subscription;
  private _intervalo = timer(0, 300000);

  private _configResultados: ApiConfig = {
    Debug: false,
    Prefixo: '/resultados',
    UrlDebug: '',
  };

  private _configEquipes: ApiConfig = {
    Debug: false,
    Prefixo: '/equipes',
    UrlDebug: '',
  };

  private _resultados: any;
  private _equipes: any;
  private _loading = false;

  constructor(
    private _rest: RestClientService
  ) {
    this._rest.get(this._configEquipes).subscribe(equipes => {
      this._equipes = equipes.data;
    });
  }

  ngOnInit() {
    this.refreshJogo();
  }

  get resultados() {
    return this._resultados;
  }

  get equipes() {
    return this._equipes;
  }

  get loading() {
    return this._loading;
  }

  private refreshJogo() {
    const resultados = this._intervalo.pipe(switchMap(() => this._rest.get(this._configResultados, '/aovivo')));
    this._resultadosSubscription = resultados.subscribe(aoVivo => this._resultados = aoVivo.data);
  }

  getImagemEquipe(equipeBusca) {
    let enderecoImagem;
    const lastIndexOfSearch = equipeBusca.lastIndexOf('/');
    const codigoEquipeBusca = equipeBusca.substring(lastIndexOfSearch + 1, equipeBusca.length);
    this._equipes.some(equipe => {
      const lastIndexOfEquipe = equipe._links.self.href.lastIndexOf('/');
      const codigoEquipe = equipe._links.self.href.substring(lastIndexOfEquipe + 1, equipe._links.self.href.length);
      if (codigoEquipe === codigoEquipeBusca) {
        enderecoImagem = equipe.crestUrl;
        return;
      }
    });
    return enderecoImagem;
  }

  traduzirNomeEquipe(nome) {
    switch (nome) {
      case 'Russia': return 'Rússia';
      case 'Saudi Arabia': return 'Arábia Saudita';
      case 'Egypt': return 'Egito';
      case 'Uruguay': return 'Uruguai';
      case 'Morocco': return 'Marrocos';
      case 'Iran': return 'Irã';
      case 'Portugal': return 'Portugal';
      case 'Spain': return 'Espanha';
      case 'France': return 'França';
      case 'Australia': return 'Austrália';
      case 'Argentina': return 'Argentina';
      case 'Iceland': return 'Islândia';
      case 'Peru': return 'Peru';
      case 'Denmark': return 'Dinamarca';
      case 'Croatia': return 'Croácia';
      case 'Nigeria': return 'Nigéria';
      case 'Costa Rica': return 'Costa Rica';
      case 'Serbia': return 'Sérvia';
      case 'Germany': return 'Alemanha';
      case 'Mexico': return 'México';
      case 'Brazil': return 'Brasil';
      case 'Switzerland': return 'Suíça';
      case 'Sweden': return 'Suécia';
      case 'Korea Republic': return 'Coreia do Sul';
      case 'Belgium': return 'Bélgica';
      case 'Panama': return 'Panamá';
      case 'Tunisia': return 'Tunísia';
      case 'England': return 'Inglaterra';
      case 'Colombia': return 'Colômbia';
      case 'Japan': return 'Japão';
      case 'Poland': return 'Polônia';
      case 'Senegal': return 'Senegal';
      default: return 'Erro';
    }
  }

  getImagemUsuario(email) {
    return `https://www.gravatar.com/avatar/${md5(email)}?d=404`;
  }

  ngOnDestroy() {
    this._resultadosSubscription.unsubscribe();
  }

}
