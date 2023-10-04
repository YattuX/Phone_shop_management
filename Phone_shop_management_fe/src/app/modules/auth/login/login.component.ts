import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UserService } from 'src/app/shared/services/user.service';
import { LocalstorageService } from 'src/app/shared/services/localstorage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  form: FormGroup

  constructor(
    private router:Router,
    private _auth: AuthService,
    private _user: UserService,
    private _formBuilder: FormBuilder,
    private _localstorage:LocalstorageService,
    private _activatedRoute:ActivatedRoute,
    ){
      this.form = this._formBuilder.group({
        username: [null, Validators.required],
        password: [null, Validators.required]
      })
    }

  hide:boolean = true;

  login(){
    if(!this.form.valid) return;
    this._auth.login(this.form.get('username')?.value, this.form.get('password')?.value).subscribe({
      next : (user) => {
        this._localstorage.setToken(user);
        this._user.setCurrentUser(user);
        const returnUrl = this._activatedRoute.snapshot.queryParamMap.get('returnUrl');
        if (returnUrl) {
          this.router.navigateByUrl(returnUrl);
        } else {
          this.router.navigate(['/']);
        }
      },
      error: error => console.log(error.error)
    })
  }
}
