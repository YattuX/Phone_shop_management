import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit, Optional } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { ArticleDTO, CaracteristiqueDTO, CouleurDTO, CreateArticleCommand, EtatDTO, KadaService, MarqueDTO, ModelDTO, ParticulariteDTO, SearchDTO, StockageDTO, TypeArticleDTO, TypeDTO, UpdateArticleCommand } from "src/app/shared/services/kada.service";

@Component({
  templateUrl: './editProduct.dialog.html',
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class EditProductDialog implements OnInit {
  formProduit: FormGroup;
  showSpinner: boolean = false;

  listTypeArticle: TypeArticleDTO[];
  listMark: MarqueDTO[];
  listModel: ModelDTO[];
  listModelWithCaractristique: ModelDTO[];
  listStockage: StockageDTO[];
  listEtat: EtatDTO[];
  listParticularite: ParticulariteDTO[];
  listCouleur: CouleurDTO[];
  listType: TypeDTO[]
  listCaracteristique: CaracteristiqueDTO[];
  caracteristiqueId: string;
  caracteristique: any;
  title = "Modification de l'article";

  constructor(
    public dialogRef: MatDialogRef<EditProductDialog>,
    @Inject(MAT_DIALOG_DATA) public data: ArticleDTO = Object.assign({}),
    private _formBuilder: FormBuilder,
    private _toastr: ToastrService,
    private _kadaService: KadaService,
    private _cd:ChangeDetectorRef
  ) {
    this.formProduit = this._formBuilder.group({
      id:[data.id],
      modelId: [data.caracteristiques?.modelId, Validators.required],
      caracteristiqueId: [data.caracteristiqueId],
      processeurs: [data.processeurs],
      tailleEcran : [data.tailleEcran],
      ram: [data.ram],
      qualite : [data.qualite],
      description : [data.description],
      capacite : [data.capacite],
      puissance : [data.puissance],
      nombreDeSim : [data.nombreDeSim],
      stockageId : [data.stockageId],
      couleurId : [data.couleurId],
      particulariteId : [data.particulariteId],
      etatId : [data.etatId],
      position: [data.position],
      typeId : [data.typeId],
      imei : [data.imei],
    });
    this.caracteristique = data.caracteristiques;
    this.caracteristiqueId = data?.caracteristiques?.id;
    this.addValidator(this.formProduit);
    this.formProduit.controls['modelId'].disable();
    this.formProduit.updateValueAndValidity();
  }

  ngOnInit(): void {
    // this.getCaracteristiques();
    this.getCouleurs();
    this.getEtats();
    this.getMarques();
    // this.getModels();
    this.getParticularites();
    this.getStockages();
    this.getTypeArticles();
    this.getTypes();
    this.getModelsWithCaracteristique();
  }

  getModelsWithCaracteristique(){
    this._kadaService.getModelListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{notCaracteritique:'false'}
    })).subscribe(v =>{
      this.listModelWithCaractristique = v.results;
      this._cd.markForCheck();
    })
  }

  getTypeArticles(){
    this._kadaService.getTypeArticleListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listTypeArticle = v.results;
      this._cd.markForCheck();
    });
  }

  getMarques(){
    this._kadaService.getMarqueListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listMark = v.results;
      this._cd.markForCheck();
    })
  }

  getModels(){
    this._kadaService.getModelListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{notCaracteritique:'true'}
    })).subscribe(v =>{
      this.listModel = v.results;
      if(this.listModel.length == 0){
        this._toastr.warning("tous les models existants ont des caracteristiques");
      }
    })
  }

  getCaracteristique(modelId: any) {
    this._kadaService.getCaracteristiqueListPage(SearchDTO.fromJS({
      pageIndex: -1, filters: {
        model: modelId
      }
    })).subscribe(v => {
      this.caracteristique = v.results[0];
      this.caracteristiqueId = this.caracteristique.id
      this._cd.markForCheck()
      this.addValidator(this.formProduit);
      this._cd.markForCheck()
    })
  }

  addValidator(form:FormGroup){
    const keys = Object.keys(form.controls);
    const listOfStrings: string[] = keys.map(key => key);
    for(let i of listOfStrings){
      const j = i.slice(0,-2);
      var s = i.endsWith('Id') ? 'has' + j.charAt(0).toUpperCase() + j.slice(1) : 'has' + i.charAt(0).toUpperCase() + i.slice(1)
      if(this.caracteristique[s] == true){
        form.controls[i].addValidators([Validators.required]);
      }else{
        form.controls[i].removeValidators([Validators.required]);
      }
      form.controls[i].updateValueAndValidity();
    }
  }

  getStockages(){
    this._kadaService.getStockageListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listStockage = v.results;
      this._cd.markForCheck();
    })
  }

  getCouleurs(){
    this._kadaService.getCouleurListPage(SearchDTO.fromJS({
      pageIndex : -1, filters:{}
    })).subscribe(v =>{
      this.listCouleur = v.results;
      this._cd.markForCheck();
    })
  }

  getParticularites(){
    this._kadaService.getParticulariteListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listParticularite = v.results;
      this._cd.markForCheck();
    })
  }

  getEtats(){
    this._kadaService.getEtatListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listEtat = v.results;
      this._cd.markForCheck();
    })
  }

  getTypes(){
    this._kadaService.getTypeListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listType = v.results;
      this._cd.markForCheck();
    })
  }

  save() {
    if (this.formProduit.valid) {
      this.showSpinner = true;
        const data = UpdateArticleCommand.fromJS({ ...this.formProduit.value });
        data.caracteristiqueId = this.caracteristiqueId;
        this._kadaService.updateArticle(data)
          .subscribe({
            next: (response) => {
              this.showSpinner = false;
              this.formProduit.reset();
              this._cd.markForCheck();
              this._toastr.success("Produit modifié avec succès!");
              this.dialogRef.close(true);
            },
            error: (err) => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
            },
            complete: () => {
              this.showSpinner = false;
              this._cd.markForCheck()
            }
          })
       }else{
        this._toastr.error('Error ! Veillez vérifier vos champs');
      }
  }
}