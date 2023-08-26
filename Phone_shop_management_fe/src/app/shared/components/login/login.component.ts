import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  form: FormGroup

  constructor(
    private router:Router,
    private _auth: AuthService,
    private _user: UserService,
    private _formBuilder: FormBuilder){
      this.form = this._formBuilder.group({
        username: [null, Validators.required],
        password: [null, Validators.required]
      })
    }

  hide:boolean = true;

  login(){
    if(!this.form.valid) return;
    this._auth.login(this.form.get('username')?.value, this.form.get('password')?.value).subscribe({
      next : user => {
        localStorage.setItem('user', JSON.stringify(user));
        this._user.setCurrentUser(user);
        this.router.navigateByUrl('/');
      },
      error: error => console.log(error.error)
    })
  }
}
