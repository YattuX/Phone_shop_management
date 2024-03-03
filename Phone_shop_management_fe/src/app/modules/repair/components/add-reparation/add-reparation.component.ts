import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { EtatReparation, TECHNICIEN_ROLE, etatsReparationValues, statutPaiementValues } from 'src/app/core/models/Utils';
import { ArticleDTO, CreateReparationCommand, KadaService, ReparationDTO, SearchDTO, UpdateEtatReparationCommand, UpdateReparationCommand } from 'src/app/shared/services/kada.service';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-add-reparation',
  templateUrl: './add-reparation.dialog.html',
  styleUrls: ['./add-reparation.dialog.scss']
})
export class AddReparationDialog implements OnInit {
  userLists: Array<any>;
  clientsList: Array<any>;
  articlesList: Array<ArticleDTO>;
  etatsReparationList = etatsReparationValues;
  statutPaiemenetList = statutPaiementValues;
  isRestitued?:boolean;

  form: FormGroup;
  showSpinner: boolean = false;

  constructor(
    private _toastr: ToastrService,
    private _kadaService: KadaService,
    private _userService: UserService,
    private _cd: ChangeDetectorRef,
    public dialogRef: MatDialogRef<AddReparationDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { row?: ReparationDTO, action: string } = Object.assign({}),
  ) {
    this.isRestitued = data.row?.etatReparation === EtatReparation.Restituee as any;
    this.form = new FormGroup({
      clientId: new FormControl(data?.row?.clientId, [Validators.required]),
      articleId: new FormControl(data?.row?.articleId, [Validators.required]),
      descriptionProbleme: new FormControl(data?.row?.descriptionProbleme, [Validators.required]),
      dateDepot: new FormControl(data?.row?.dateDepot, [Validators.required]),
      dateLivraison: new FormControl(data?.row?.dateLivraison, []),
      coutReparation: new FormControl(data?.row?.coutReparation, [Validators.required, Validators.min(0)]),
      reparateurEnCharge: new FormControl(data?.row?.reparateurEnCharge, [Validators.required]),
      remarques: new FormControl(data?.row?.remarques,)
    });
  }

  ngOnInit(): void {
    this._userService.getUserListPage(SearchDTO.fromJS({
      filters: {
        role: TECHNICIEN_ROLE.Name
      }, pageIndex: -1
    })).subscribe(res => {
      this.userLists = res.results.map(v => ({ ...v, fullName: `${v.firstname} ${v.lastname}` }));
    });

    this._kadaService.getClientListPage(SearchDTO.fromJS({
      filters: {}, pageIndex: -1
    })).subscribe(res => {
      this.clientsList = res.results.map(v => ({ ...v, fullName: `${v.name} ${v.lastName}` }));
    });

    this._kadaService.getArticleListPage(SearchDTO.fromJS({
      filters: {}, pageIndex: -1
    })).subscribe(res => {
      this.articlesList = res.results;
    });
  }

  save() {
    if (this.form.valid) {
      this.showSpinner = true;
      let subscribe$: Observable<any>;

      if (this.data.action === 'add') {
        subscribe$ = this._kadaService.createReparation(CreateReparationCommand
          .fromJS({ ...this.form.value }));
      } else {
        subscribe$ = this._kadaService.updateReparation(UpdateReparationCommand
          .fromJS({ ...this.form.value, id: this.data.row.id }));
      }

      subscribe$
        .subscribe({
          next: (response) => {
            this.showSpinner = false;
            this.form.reset();
            this._cd.markForCheck();
            this._toastr.success(`Reparation ${this.title.replace('er', "ée")} avec succès!`);
            this.dialogRef.close(true);
          },
          error: (err) => {
            this.showSpinner = false;
            this._cd.markForCheck()
            this._toastr.error(convertErrorObjectToString(err?.errors), `${err.title}`, {
              timeOut: 10000
            });
          },
          complete: () => {
            this.showSpinner = false;
            this._cd.markForCheck()
          }
        })
    } else {
      this._toastr.error('Error ! Veillez vérifier vos champs');
    }
  }

  get title() {
    return this.data.action === "add" ? "Ajouter " : "Modifier "
  }

  getTitleButton() {
    switch (this.data.row.etatReparation) {
      case EtatReparation.EnAttente as any:
        return "Commencer la réparation";
      case EtatReparation.EnCours as any:
        return "Terminer la réparation";
      case EtatReparation.Terminee as any:
        return "Restituer l'article'";
      case EtatReparation.Restituee as any:
        return "Réparation restituée";
      default:
        return "";
    }
  }
  
  updateEtat() {
    this._kadaService.updateEtatReparation(UpdateEtatReparationCommand.fromJS({
      id: this.data.row.id
    })).subscribe({
      next: (response) => {
        this.showSpinner = false;
        this.form.reset();
        this._cd.markForCheck();
        this._toastr.success(`Reparation ${this.title.replace('er', "ée")} avec succès!`);
        this.dialogRef.close(true);
      },
      error: (err) => {
        this.showSpinner = false;
        this._cd.markForCheck()
        this._toastr.error(convertErrorObjectToString(err?.errors), `${err.title}`, {
          timeOut: 10000
        });
      },
      complete: () => {
        this.showSpinner = false;
        this._cd.markForCheck()
      }
    })
  }
}

export function convertErrorObjectToString(errorObject: { [key: string]: string[] }): string {
  // if(!errorObject) return "Une erreur s'est produite"
  let errorString = '';

  for (const key in errorObject) {
    if (errorObject.hasOwnProperty(key)) {
      const errorMessageArray = errorObject[key];
      errorMessageArray.forEach(errorMessage => {
        errorString += `${key}: ${errorMessage}\n`;
      });
    }
  }

  return errorString;
}

