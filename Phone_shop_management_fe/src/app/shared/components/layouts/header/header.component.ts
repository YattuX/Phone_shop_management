import { Component } from '@angular/core';
import { AuthService, IAuthResponse } from 'src/app/shared/services/auth.service';
import { LocalstorageService } from 'src/app/shared/services/localstorage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  User:IAuthResponse;  
  constructor(
    private _autService:AuthService,
    private _localStorageSerive: LocalstorageService,
  ) {
    this.User = _localStorageSerive.User;
  }

  logout(){
    this._autService.logout();
  }
}
