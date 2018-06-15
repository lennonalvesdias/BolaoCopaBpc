import { Component, OnInit } from '@angular/core';

import { ApiConfig } from '../../shared/models/api-config.interface';
import { RestClientService } from '../../shared/services/rest-client.service';
import { AuthService } from '../../shared/auth/auth.service';

@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrls: ['./resultados.component.scss']
})
export class ResultadosComponent implements OnInit {

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

  constructor(
    private _auth: AuthService,
    private _rest: RestClientService
  ) {
    this._rest.get(this._configResultados).subscribe(resultados => {
      this._resultados = resultados.data;
    });

    this._rest.get(this._configEquipes).subscribe(resultados => {
      this._equipes = resultados.data;
    });
  }

  ngOnInit() {
  }

  get resultados() {
    return this._resultados;
  }

  get equipes() {
    return this._equipes;
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

  getCodigoEquipe(equipeHref) {
    const lastIndexOfSearch = equipeHref.lastIndexOf('/');
    return equipeHref.substring(lastIndexOfSearch + 1, equipeHref.length);
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

  getPalpiteJogo(codigoMandante: number, codigoVisitante: number, placarDoMandante: boolean) {
    // tslint:disable-next-line:max-line-length
    const palpiteDoJogo = this._resultados.filter(x => x.mandanteTime.toString() === codigoMandante && x.visitanteTime.toString() === codigoVisitante);
    if (palpiteDoJogo[0]) {
      if (placarDoMandante === true) {
        return palpiteDoJogo[0].mandantePlacar;
      } else {
        return palpiteDoJogo[0].visitantePlacar;
      }
    }
  }

  getVisualizacaoVencedor(golsFavor: number, golsContra: number) {
    if (golsFavor === null) {
      return '';
    }
    if (golsFavor > golsContra) {
      return 'green';
    } else if (golsFavor < golsContra) {
      return 'red';
    } else if (golsFavor === golsContra) {
      return '#15aabf';
    } else {
      return '';
    }
  }
}
