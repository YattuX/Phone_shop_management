import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UserService } from 'src/app/shared/services/user.service';
import { LocalstorageService } from 'src/app/shared/services/localstorage.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  form: FormGroup
  loading = false;

  constructor(
    private router: Router,
    private _auth: AuthService,
    private _user: UserService,
    private _formBuilder: FormBuilder,
    private _localstorage: LocalstorageService,
    private _activatedRoute: ActivatedRoute,
    private _cdr:ChangeDetectorRef,
    private _toastr:ToastrService
  ) {
    this.form = this._formBuilder.group({
      username: [null, Validators.required],
      password: [null, Validators.required]
    })
  }

  hide: boolean = true;

  login() {
    if (!this.form.valid) return;
    this.loading = true;
    this._auth.login(this.form.get('username')?.value, this.form.get('password')?.value).subscribe({
      next: (user) => {
        this._localstorage.setToken(user);
        this._user.setCurrentUser(user);
        this.loading = false;
        this._cdr.detectChanges();
        const returnUrl = this._activatedRoute.snapshot.queryParamMap.get('returnUrl');
        if (returnUrl) {
          this.router.navigateByUrl(returnUrl);
        } else {
          this.router.navigate(['/']);
        }
      },
      error: (error) => {
        if(!error.response){
          this._toastr.error(error.message,"Erreur de Connection")
        }else{
          let response = JSON.parse(error.response);
          this._toastr.error("Nom d'utilisateur ou mot de passe incorrect",response.type);          
        }
        this.loading = false;
        this._cdr.detectChanges();
      },
      complete:()=>{
        this.loading = false;
        this._cdr.detectChanges();
      }
    })
  }
}
