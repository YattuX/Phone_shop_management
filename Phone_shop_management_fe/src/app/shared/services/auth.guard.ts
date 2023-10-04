import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LocalstorageService } from './localstorage.service';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private _localStorage: LocalstorageService, private _router:Router, private _autService:AuthService) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean{
    if (this._localStorage.isAuthenticated()) {
      let role = this._localStorage.getRoleUser();
      return role.includes('Administrateur');
    }else{
      this._autService.logout();
      return false;
    }
  }

}
