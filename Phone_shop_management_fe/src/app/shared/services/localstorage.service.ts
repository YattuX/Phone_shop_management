import { Injectable } from '@angular/core';
import { IAuthResponse } from './auth.service';
import { Observable, filter, map, takeUntil, timer } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {
  private tokenKey = 'user';

  setToken(token: object) {
    localStorage.setItem(this.tokenKey, JSON.stringify(token));
  }

  // Méthode pour récupérer le token du local storage
  getToken() {
    let user = this.User;
    return user?.token;
  }

  // Méthode pour vérifier si l'utilisateur est authentifié
  isAuthenticated() {
    if (!this.getToken())
      return false;
    return this.getTokenExpiration()?.getTime() > new Date().getTime();
  }

  removeToken() {
    localStorage.removeItem(this.tokenKey);
  }

  getTokenExpiration = () => {
    let user = this.User;
    return user ? (new Date(user.dateTokenExpiration)) : undefined;
  }

  getRoleUser = () => {
    let user = this.User;
    return user.role;
  }
  get User() {
    return JSON.parse(localStorage.getItem(this.tokenKey)) as IAuthResponse;
  }
}
