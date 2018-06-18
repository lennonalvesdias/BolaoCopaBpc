import { Component, OnInit } from '@angular/core';
import { Md5 } from 'ts-md5/dist/md5';
import { AuthService } from '../../shared/auth/auth.service';
import { RestClientService } from '../../shared/services/rest-client.service';
import { ApiConfig } from '../../shared/models/api-config.interface';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss']
})
export class RankingComponent implements OnInit {
  private _configRanking: ApiConfig = {
    Debug: false,
    Prefixo: '/ranking',
    UrlDebug: '',
  };

  private _resultados: any;

  constructor(
    private _auth: AuthService,
    private _rest: RestClientService
  ) {
    this._rest.get(this._configRanking).subscribe(resultados => {
      this._resultados = resultados.data;
    });
  }

  ngOnInit() {
  }

  get resultados() {
    return this._resultados;
  }

  getGravatarLink (email: string) {
    // tslint:disable-next-line:max-line-length
    return 'http://www.gravatar.com/avatar/' +  Md5.hashStr(email) + '?s=250&d=404' ;
  }
}
