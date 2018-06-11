// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs/Rx';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';

import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private _rota: Router,
    private _authService: AuthService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | boolean {
    if (this._authService.usuarioAutenticado()) {
      return true;
    }

    this._rota.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
