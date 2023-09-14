import { Component, Inject, Optional } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { KadaService } from "src/app/shared/services/kada.service";

@Component({
    templateUrl: './provider.dialog.html',
})
export class ProviderDialog {
    showSpinner = false;
    form: FormGroup = new FormGroup({
        lastName: new FormControl(null, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]),
        name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
        email: new FormControl(null, [Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{1,}\.+[a-zA-Z]{2,}$'), Validators.maxLength(100)]),
        whatsappNumber: new FormControl(null, [Validators.maxLength(20)]),
    });

    constructor(
        public dialogRef: MatDialogRef<ProviderDialog>,
        private _kadaService: KadaService,
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

    save() {
        if (this.form.valid) {
            if (this.data?.action === 'add') {
                this._kadaService.createFournisseur({ ...this.form.value })
                    .subscribe({
                        next: (response) => {
                            this.dialogRef.close(true);
                            this._toastr.success("Fournisseur ajouté avec succès!");
                        },
                        error: (err) => {
                            this._toastr.error(`Erreur! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
                            this.showSpinner = false;
                        },
                        complete: () => {
                            this.showSpinner = false;
                        }
                    })
            }else{
                this._kadaService.updateFournisseur({ ...this.form.value,id:this.data?.id })
                    .subscribe({
                        next: (response) => {
                            this.dialogRef.close(true);
                            this._toastr.success("Fournisseur modifié avec succès!");
                        },
                        error: (err) => {
                            this._toastr.error(`Erreur! Veuillez réessayer!\n ${err.title}`);
                            this.showSpinner = false;
                        },
                        complete: () => {
                            this.showSpinner = false;
                        }
                    })
            }
        }
    }
}