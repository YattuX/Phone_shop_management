import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {
  private tokenKey = 'user';

  setToken(token: string) {
    localStorage.setItem(this.tokenKey, JSON.stringify(token));
  }

  // Méthode pour récupérer le token du local storage
  getToken() {
    let user = JSON.parse(localStorage.getItem(this.tokenKey)!);
    return user?.token;
  }

  // Méthode pour vérifier si l'utilisateur est authentifié
  isAuthenticated() {
    return !!this.getToken();
  }

  removeToken(){
    localStorage.removeItem(this.tokenKey);
  }
}
