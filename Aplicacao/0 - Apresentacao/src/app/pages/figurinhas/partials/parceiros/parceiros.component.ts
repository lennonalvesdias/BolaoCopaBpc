import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'figurinhas-parceiros',
  templateUrl: './parceiros.component.html',
  styles: []
})
export class FigurinhasParceirosComponent implements OnInit {

  private _apoiadores = [
    { nome: 'Alves Dias', imagem: 'alvesdias.png', link: 'http://alvesdias.com.br' },
    { nome: 'E+', imagem: 'emais.png', link: '' },
    { nome: 'Secretaria da Cultura', imagem: 'cultura.png', link: '' },
    { nome: 'Prefeitura Municipal de Marília', imagem: 'prefeitura.png', link: '' },
    { nome: 'PUC Esmeralda Shopping', imagem: 'puc.png', link: '' },
    { nome: 'LIFE Internet', imagem: 'life.png', link: '' }
  ];

  constructor() { }

  ngOnInit() {
  }

  get apoiadores() {
    return this._apoiadores;
  }

}
