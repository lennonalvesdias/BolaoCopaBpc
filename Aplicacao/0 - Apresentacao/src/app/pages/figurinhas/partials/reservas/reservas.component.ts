import { ApiConfig } from './../../../../shared/models/api-config.interface';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import * as _swal from 'sweetalert';
import { SweetAlert } from 'sweetalert/typings/core';
import { RestClientService } from '../../../../shared/services/rest-client.service';
const swal: SweetAlert = _swal as any;

// import * as $ from 'jquery';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'figurinhas-reservas',
  templateUrl: './reservas.component.html',
  styles: []
})
export class FigurinhasReservasComponent implements OnInit {

  public isMobile: Boolean = /mobile/i.test(navigator.userAgent);

  public formularioReserva: FormGroup;
  private _config: ApiConfig;
  private _mascaras: any;

  constructor(
    private _formBuilder: FormBuilder,
    private _rest: RestClientService
  ) {
    this.formularioReserva = this._formBuilder.group({
      cpf: ['', Validators.required],
      nome: ['', Validators.required],
      email: ['', Validators.required],
      ddd: ['', Validators.required],
      telefone: ['', Validators.required],
      rua: ['', Validators.required],
      ncasa: ['', Validators.required],
      cidade: ['', Validators.required],
      estado: ['', Validators.required]
    });

    this._config = {
      Debug: false,
      Prefixo: '/usuarios',
      UrlDebug: 'http://localhost:5151/usuarios'
    };
    
    this._mascaras = {
      cpf: [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/],
      ddd: [/\d/, /\d/],
      telefone: [/\d/, /\d/, /\d/, /\d/, /\d/, '-',  /\d/, /\d/, /\d/, /\d/],
      estado: [/\w/, /\w/]
    };
  }

  ngOnInit() {
  }

  reservar() {
    if (!this.formularioReserva.valid) {
      swal('Ops!', 'Favor preencher todos os campos do formulário.', 'error');
    } else {
      const ncasa_rgx = this.formularioReserva.value['ncasa'].replace(/\D/g, '');
      const codigoArea_rgx = this.formularioReserva.value['ddd'].replace(/\D/g, '');
      const telefone_rgx = this.formularioReserva.value['telefone'].replace(/\D/g, '');
      const cpf_rgx = this.formularioReserva.value['cpf'].replace(/\D/g, '');

      const reserva_payload = {
        'nome': this.formularioReserva.value['nome'],
        'endereco': {
          'rua': this.formularioReserva.value['rua'],
          'numero': ncasa_rgx,
          'complemento': this.formularioReserva.value['complemento'],
          'bairro': this.formularioReserva.value['bairro'],
          'cidade': this.formularioReserva.value['cidade'],
          'estado': this.formularioReserva.value['estado']
        },
        'email': this.formularioReserva.value['email'],
        'telefone': {
          'codigoArea': codigoArea_rgx,
          'numero': telefone_rgx
        },
        'cpf': cpf_rgx
      };

      console.log(reserva_payload);

      this._rest.post(this._config, '/reservar', reserva_payload).subscribe(
        data => {
          // console.log(data);
          swal('Parabéns!', 'Sua reserva foi feita com sucesso!', 'success');
          this.formularioReserva.reset();
        }, error => {
          // console.log(error);
          const regex = /\[.*\]/g;
          const error_response = regex.exec(error['_body']);
          // tslint:disable-next-line:max-line-length
          swal('Ops!', 'ERRO: ' + error_response.toString().replace(/\[/g, '').replace(/\]/g, '').replace(/"/g, '').replace(/\,/g, ' '), 'error');
        });
    }
  }

  get mascaras() {
    return this._mascaras;
  }

}
