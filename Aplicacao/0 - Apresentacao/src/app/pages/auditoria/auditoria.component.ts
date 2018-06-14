import { Component, OnInit } from '@angular/core';
import { ApiConfig } from '../../shared/models/api-config.interface';
import { RestClientService } from '../../shared/services/rest-client.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-auditoria',
  templateUrl: './auditoria.component.html',
  styleUrls: ['./auditoria.component.scss']
})
export class AuditoriaComponent implements OnInit {

  public _formularioAuditoria: FormGroup;
  private _loading = false;

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

  private _configAuditoria: ApiConfig = {
    Debug: true,
    Prefixo: '/auditoria',
    UrlDebug: 'http://localhost:58202',
  };

  private _palpites: any;
  private _resultados: any;
  private _equipes: any;

  constructor(
    private _rest: RestClientService,
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService
  ) {
    this._formularioAuditoria = this._formBuilder.group({
      email: ['', Validators.required]
    });

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

  get palpites() {
    return this._palpites;
  }

  get loading() {
    return this._loading;
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

  temPalpite(codigoMandante, codigoVisitante) {
    // tslint:disable-next-line:max-line-length
    const palpiteDoJogo = this._palpites.filter(x => x.mandanteTime.toString() === codigoMandante && x.visitanteTime.toString() === codigoVisitante);
    if (palpiteDoJogo[0]) {
      return true;
    } else {
      return false;
    }
  }

  buscarPalpites() {
    this._loading = true;
    const segmentoAuditoria = `/${this._formularioAuditoria.value['email']}`;
    this._rest.get(this._configAuditoria, segmentoAuditoria).subscribe(palpites => {
      if (palpites.success === true && palpites.data[0]) {
        this._palpites = palpites.data;
      } else if (palpites.success === true && !palpites.data[0]) {
        this._toastr.error('Nenhum palpite encontrado.', 'Ops!');
      }
      this._loading = false;
    }, error => {
      const regex = /\[.*\]/g;
      const error_response = regex.exec(error['_body']);
      // tslint:disable-next-line:max-line-length
      this._toastr.error(error_response.toString().replace(/\[/g, '').replace(/\]/g, '').replace(/"/g, '').replace(/\,/g, ' '), 'Ops!');
      this._loading = false;
    });
  }

}
