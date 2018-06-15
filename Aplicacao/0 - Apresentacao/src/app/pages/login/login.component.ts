import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from './../../shared/auth/auth.service';

import swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public _formularioLogin: FormGroup;
  public _formularioNovaSenha: FormGroup;

  private _senhaPadrao = false;
  private _loading = false;
  private _formError = false;

  constructor(
    private _formBuilder: FormBuilder,
    private _auth: AuthService
  ) {
    this._formularioLogin = this._formBuilder.group({
      email: ['', Validators.required],
      senha: ['', Validators.required]
    });

    this._formularioNovaSenha = this._formBuilder.group({
      novaSenha: ['', Validators.required],
      novaSenhaConfirmacao: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  entrar() {
    this._loading = true;

    this._loading = true;
    this._auth.setToken(this._formularioLogin.value).subscribe(data => {
      if (data.authenticated === false) {
        swal('Ops!', 'ERRO: ' + data.message, 'error');
        this._auth.autenticacao(false, data, false);
      } else {
        this._auth.atualizarUsuario(this._formularioLogin.value['email']);

        if (this._formularioLogin.value['senha'] === 'bpc@2018') {
          this._senhaPadrao = true;
          swal('Calma lá', 'Precisamos mudar essa senha né?', 'info');
        } else {
          this._senhaPadrao = false;
          swal('Boa parça!', 'Autenticado(a) com sucesso.', 'success');
        }

        this._auth.autenticacao(true, data, this._senhaPadrao);
      }
      this._loading = false;
    }, error => {
      this._auth.autenticacao(false, null, this._senhaPadrao);
      const regex = /\[.*\]/g;
      const error_response = regex.exec(error['_body']);
      // tslint:disable-next-line:max-line-length
      swal('Ops!', 'ERRO: ' + error_response.toString().replace(/\[/g, '').replace(/\]/g, '').replace(/"/g, '').replace(/\,/g, ' '), 'error');
      this._loading = false;
    });
  }

  atualizarSenha() {
    this._auth.userUpdate(this._formularioNovaSenha.value).subscribe(data => {
      if (data.authenticated === false) {
        swal('Ops!', 'ERRO: ' + data.message, 'error');
        this._auth.autenticacao(false, null, false);
      } else {
        swal('Boa parça!', 'Agora você está pronto(a) para soltar seus palpites.', 'success');
        this._auth.atualizarRota();
      }
      this._loading = false;
    }, error => {
      this._auth.autenticacao(false, null, this._senhaPadrao);
      const regex = /\[.*\]/g;
      const error_response = regex.exec(error['_body']);
      // tslint:disable-next-line:max-line-length
      swal('Ops!', 'ERRO: ' + error_response.toString().replace(/\[/g, '').replace(/\]/g, '').replace(/"/g, '').replace(/\,/g, ' '), 'error');
      this._loading = false;
    });
  }

  get loading() {
    return this._loading;
  }

  get senhaPadrao() {
    return this._senhaPadrao;
  }

  get formError() {
    return this._formError;
  }

}
