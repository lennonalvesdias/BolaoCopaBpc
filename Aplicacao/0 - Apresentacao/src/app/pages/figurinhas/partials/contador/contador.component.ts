import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'figurinhas-contador',
  templateUrl: './contador.component.html',
  styles: [`
    /deep/ .countdown {
      width: 100%;
      height: 100px;
      background: #777777;
    }
    /deep/ .two-dots {
      display: none;
    }
    /deep/ .measurements {
      margin-right: 5px;
      padding: 10px;
    }
    /deep/ .measurements-number {
      color: #ffffff;
      font-size: 40px;
    }
    /deep/ .measurements-text {
      color: #ffffff;
    }
    /deep/ .divider {
      font-size: 60px;
    }
  `]
})
export class FigurinhasContadorComponent implements OnInit {

  private _countdown_text = {
    Year: 'Ano(s)',
    Month: 'Mês(es)',
    Weeks: 'Semana(s)',
    Days: 'Dia(s)',
    Hours: 'Hora(s)',
    Minutes: 'Minuto(s)',
    Seconds: 'Segundo(s)',
    MilliSeconds: 'Milisegundo(s)'
  };

  constructor() { }

  ngOnInit() {
  }

  get countdown_text() {
    return this._countdown_text;
  }

}
