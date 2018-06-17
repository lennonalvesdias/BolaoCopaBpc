import { Component, OnInit } from '@angular/core';

import { ApiConfig } from '../../shared/models/api-config.interface';
import { RestClientService } from '../../shared/services/rest-client.service';
import { AuthService } from '../../shared/auth/auth.service';

import { ToastrService } from 'ngx-toastr';
import swal from 'sweetalert2';

@Component({
  selector: 'app-palpites',
  templateUrl: './palpites.component.html',
  styleUrls: ['./palpites.component.scss']
})
export class PalpitesComponent implements OnInit {

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

  private _configPalpites: ApiConfig = {
    Debug: false,
    Prefixo: '/palpites',
    UrlDebug: '',
  };

  private _palpites: any;
  private _resultados: any;
  private _equipes: any;

  constructor(
    private _auth: AuthService,
    private _rest: RestClientService,
    private _toastr: ToastrService
  ) {
    this._rest.get(this._configResultados).subscribe(resultados => {
      this._resultados = resultados.data;
    });

    this._rest.get(this._configEquipes).subscribe(resultados => {
      this._equipes = resultados.data;
    });

    const segmentoPalpites = `/usuario/${this._auth.usuarioEmail}`;
    this._rest.get(this._configPalpites, segmentoPalpites).subscribe(palpites => {
      this._palpites = palpites.data;
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

  get palpites() {
    return this._palpites;
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

  palpitar(placarMandante, placarVisitante) {
    if (!placarMandante.value || !placarVisitante.value) {
      swal('Ops!', 'Placar vazio você complica o desenvolvedor né?', 'error');
      return;
    }

    if (placarMandante.value < 0 || placarVisitante.value < 0) {
      swal('Ops!', 'Negativo?! You ta de brincation uite me, cara?', 'error');
      return;
    }

    const palpite = {
      email: this._auth.usuarioEmail,
      mandantePlacar: placarMandante.value,
      mandanteTime: placarMandante.name,
      visitantePlacar: placarVisitante.value,
      visitanteTime: placarVisitante.name
    };

    const segmento = '/palpitar';
    this._rest.post(this._configPalpites, segmento, palpite).subscribe(data => {
      this._toastr.success('Seu palpite está na conta!', 'Boa!');
    }, error => {
      const regex = /\[.*\]/g;
      const error_response = regex.exec(error['_body']);
      // tslint:disable-next-line:max-line-length
      this._toastr.error(error_response.toString().replace(/\[/g, '').replace(/\]/g, '').replace(/"/g, '').replace(/\,/g, ' '), 'Ops!');
    });
  }

  getPalpiteJogo(codigoMandante, codigoVisitante, placarDoMandante) {
    // tslint:disable-next-line:max-line-length
    const palpiteDoJogo = this._palpites.filter(x => x.mandanteTime.toString() === codigoMandante && x.visitanteTime.toString() === codigoVisitante);
    if (palpiteDoJogo[0]) {
      if (placarDoMandante === true) {
        return palpiteDoJogo[0].mandantePlacar;
      } else {
        return palpiteDoJogo[0].visitantePlacar;
      }
    }
  }

}
