import { Component, Inject, OnInit, Optional } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ApiException, AuthService } from 'src/app/shared/services/auth.service';
import { KadaService } from 'src/app/shared/services/kada.service';
import { RoleModel } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './user.dialog.html',
  styleUrls: ['./user.dialog.scss']
})
export class AddUserDialog implements OnInit{
  showSpinner = false;
  userRoles$:Observable<RoleModel[]>;
  hide = true;
  form: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.maxLength(100), Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    email: new FormControl('', [Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{1,}\.+[a-zA-Z]{2,}$'), Validators.maxLength(100), Validators.required]),
    phoneNumber: new FormControl('', [Validators.maxLength(20), Validators.required]),
    userName: new FormControl('',[Validators.required]),
    role: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required,Validators.minLength(6),
      Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&!*_])[A-Za-z\d@#$%^&!*_]+$/)]),
    confirmPassword: new FormControl('',[Validators.required])
  });
  
  constructor(
    public dialogRef: MatDialogRef<AddUserDialog>,
    private _kadaService: KadaService,
    private _authService:AuthService,
    private _toastr: ToastrService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    if (data?.action == 'edit') {
      this.form.patchValue({
        lastName: data.lastName,
        name: data.name,
        email: data.email,
        whatsappNumber: data.whatsappNumber,
      })
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
              let obj = JSON.parse(err.response);
              this._toastr.error(`${obj?.title}`,obj?.type);
              this.showSpinner = false;
            },
            complete: () => {
              this.showSpinner = false;
            }
          })
      } else {
        // this._kadaService.updateFournisseur({ ...this.form.value, id: this.data?.id })
        //   .subscribe({
        //     next: (response) => {
        //       this.dialogRef.close(true);
        //       this._toastr.success("Fournisseur modifié avec succès!");
        //     },
        //     error: (err) => {
        //       this._toastr.error(`Erreur! Veuillez réessayer!\n ${err.title}`);
        //       this.showSpinner = false;
        //     },
        //     complete: () => {
        //       this.showSpinner = false;
        //     }
        //   })
      }
    }
  }
}
