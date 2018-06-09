import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FigurinhasRoutingModule } from './figurinhas-routing.module';
import { AgmCoreModule } from '@agm/core';
import { CountDown } from 'ng2-date-countdown';
import { TextMaskModule } from 'angular2-text-mask';

import { FigurinhasComponent } from './figurinhas.component';
import { FigurinhasBannerComponent } from './partials/banner/banner.component';
import { FigurinhasReservasComponent } from './partials/reservas/reservas.component';
import { FigurinhasContadorComponent } from './partials/contador/contador.component';
import { FigurinhasMapaComponent } from './partials/mapa/mapa.component';
import { FigurinhasAgendaComponent } from './partials/agenda/agenda.component';
import { FigurinhasParceirosComponent } from './partials/parceiros/parceiros.component';
import { FigurinhasSobreComponent } from './partials/sobre/sobre.component';
import { FigurinhasInformativoComponent } from './partials/informativo/informativo.component';

@NgModule({
  imports: [
    CommonModule,
    FigurinhasRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCuGVl9qaH_BOTE3PYLiodZpu37w88kj4g'
    }),
    TextMaskModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    CountDown,
    FigurinhasComponent,
    FigurinhasBannerComponent,
    FigurinhasReservasComponent,
    FigurinhasContadorComponent,
    FigurinhasMapaComponent,
    FigurinhasAgendaComponent,
    FigurinhasParceirosComponent,
    FigurinhasSobreComponent,
    FigurinhasInformativoComponent
  ]
})
export class FigurinhasModule { }
