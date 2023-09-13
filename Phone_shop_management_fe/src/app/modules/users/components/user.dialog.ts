import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/shared/services/auth.service';
import { KadaService } from 'src/app/shared/services/kada.service';
import { RoleModel, UserModelUpdate, UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './user.dialog.html',
  styleUrls: ['./user.dialog.scss']
})
export class AddUserDialog implements OnInit {
  showSpinner = false;
  userRoles$:Observable<RoleModel[]>;
  hide = true;
  form: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.maxLength(100), Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    email: new FormControl('', [Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{1,}\.+[a-zA-Z]{2,}$'), Validators.maxLength(100), Validators.required]),
    phoneNumber: new FormControl('', [Validators.maxLength(20), Validators.required]),
    userName: new FormControl('', [Validators.required]),
    role: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(6),
    Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&!*_])[A-Za-z\d@#$%^&!*_]+$/)]),
    confirmPassword: new FormControl('', [Validators.required])
  });

  constructor(
    public dialogRef: MatDialogRef<AddUserDialog>,
    private _kadaService: KadaService,
    private _authService: AuthService,
    private _toastr: ToastrService,
    private _userService: UserService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    if (data?.action == 'edit') {
      this.form.patchValue({
        lastName: data.lastname,
        firstName: data.firstname,
        email: data.email,
        phoneNumber: data.phoneNumber,
        userName: data.username,
        role: data.roles?.map((v:any)=>v?.normalizedName)
      });
      this.removeValidators(this.form, ['password', 'confirmPassword']);
      this.disableControls(this.form, ['password', 'confirmPassword']);
    }
  }
  ngOnInit(): void {
    this.userRoles$ = this._kadaService.getRoleListPage()
  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      if (this.data?.action === 'add') {
        let values = this.form.value;
        this._authService.register(
          values['firstName'],
          values['lastName'],
          values['email'],
          values['phoneNumber'],
          values['userName'],
          values['role'],
          values['password']
        ).subscribe({
          next: (response) => {
            this.dialogRef.close(true);
            this._toastr.success("Utilisateur ajouté avec succès!");
          },
          error: (err) => {
            if (!err?.response) {
              this._toastr.error(`${err.message}`, "Erreur");
            } else {
              let obj = JSON.parse(err.response);
              this._toastr.error(`${obj?.title}`, obj?.type);
            }
            this.showSpinner = false;
          },
          complete: () => {
            this.showSpinner = false;
          }
        })
      } else {
        this._userService.updateUser(UserModelUpdate.fromJS({
          id: this.data.id,
          username: this.form.value['userName'],
          email: this.form.value['email'],
          firstname: this.form.value['firstName'],
          lastname: this.form.value['lastName'],
          phoneNumber: this.form.value['phoneNumber'],
          roles: this.form.value['role']
        }))
          .subscribe({
            next: (response) => {
              this.dialogRef.close(true);
              this._toastr.success("Utilisateur modifié avec succès!");
            },
            error: (err) => {
              if (!err?.response) {
                this._toastr.error(`${err.message}`, "Erreur");
              } else {
                let obj = JSON.parse(err.response);
                this._toastr.error(`${obj?.title}`, obj?.type);
              }
              this.showSpinner = false;
            },
            complete: () => {
              this.showSpinner = false;
            }
          })
      }
    }
  }

  removeValidators(form: FormGroup, controls: string[]) {
    controls.forEach(v => {
      form.controls[v].removeValidators(Validators.required);
    })
  }
  disableControls(form: FormGroup, controls: string[]) {
    controls.forEach(v => {
      form.controls[v].disable();
    })
  }
}
