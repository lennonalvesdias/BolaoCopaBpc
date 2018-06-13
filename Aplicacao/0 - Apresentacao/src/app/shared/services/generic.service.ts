import { Injectable, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class GenericService {

    isLoading: boolean;
    loadingChange: Subject<boolean> = new Subject<boolean>();

    constructor() {
        this.loadingChange.subscribe((value) => {
            this.isLoading = value;
        });
    }

    emitters: {
        [nomeEvento: string]: EventEmitter<any>
    } = {};

    setLoading(value: boolean) {
        this.loadingChange.next(value);
    }

    listaDeEventos(nomeEvento: string): EventEmitter<any> {
        // tslint:disable-next-line:curly
        if (!this.emitters[nomeEvento])
            this.emitters[nomeEvento] = new EventEmitter<any>();
        return this.emitters[nomeEvento];
    }
}
