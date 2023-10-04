import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { EMPTY, Observable } from 'rxjs';
import { LocalstorageService } from '../../services/localstorage.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { InfoDialog } from '../../components/dialogs/info/info.dialog';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(
    private storageService: LocalstorageService,
    private _authService: AuthService,
    private _toastr: ToastrService,
    private _dialog:MatDialog
  ) { }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.storageService.isAuthenticated()) {
      const token = this.storageService.getToken();
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
        withCredentials: true
      });
      return next.handle(request);
    }
    if (location.pathname.includes("/auth/login")) {
      return next.handle(request);
    } else {
      this._dialog.open(InfoDialog, {
        data: {
          title: "Expiration de la session",
          message: `<span class="font-bold text-[18px]">Votre session a expirer. voulez-vous vous reconnecter maintenant?</span><br>
          <span class="text-blue-500">Vous pouvez choisir de ne pas vous reconnecter et de rester sur cette page mais vous ne pourrez faire aucune action: Modification, Suppression ou Ajout.</span>`,
          cancelAction: "Non, rester sur cette page",
          valideAction: "Oui",
          type: "warn",
          personaliseDialog: true,
        },
      }).afterClosed()
      .subscribe(res=>{
        if(res){
          this._dialog.openDialogs.map(v=>v.close());
          this._authService.logout();
        }
      });
      return EMPTY;
    }
  }
}
