import { ChangeDetectorRef, Component, Inject, Optional, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { ToastrService } from 'ngx-toastr';
import { CaracteristiqueDTO, CouleurDTO, CreateArticleCommand, EtatDTO, KadaService, MarqueDTO, ModelDTO, ParticulariteDTO, SearchDTO, StockageDTO, TypeArticleDTO, TypeDTO } from 'src/app/shared/services/kada.service';


@Component({
  selector: 'app-product',
  templateUrl: './addProduct.html',
})
export class AddProduct {
  showSpinner: boolean = false;
  title: string = '';
  caracteristiqueId : string;
  listTypeArticle: TypeArticleDTO[];
  listMark: MarqueDTO[];
  listModel: ModelDTO[];
  listCaracteristique: CaracteristiqueDTO[];
  caracteristique: any;
  listControl: string[] = ['hasStockage', 'hasCouleur', 'hasNombreDeSim', 'hasImei', 'hasParticularite', 'hasEtat','hasProcesseursvd', 'hasTailleEcran','hasRam', 'hasQualite', 'hasType', 'hasCapacite','hasCaracteristic','hasPuissance']
  listStockage: StockageDTO[];
  listEtat: EtatDTO[];
  listParticularite: ParticulariteDTO[];
  listCouleur: CouleurDTO[];
  listType: TypeDTO[]

  formTypeArticle : FormGroup;
  formMarque : FormGroup;
  formModel : FormGroup;
  formCaracteristique : FormGroup;
  formProduit : FormGroup;
v
  @ViewChild('stepper')
  private stepper: MatStepper;

  marque : any = [
    {
      id: 1,
      name : 'Telephone',
    },
    {
      id:2,
      name : 'Tablette',
    },
    {
      id:3,
      name : 'Ordinateur',
    },
  ]
  
  constructor(
    private _formBuilder: FormBuilder,
    private _kadaService: KadaService,
    private _toastr: ToastrService,
    private _cd: ChangeDetectorRef,
  ){
    this.formTypeArticle = this._formBuilder.group({
      name: [null, [Validators.required, Validators.maxLength(50), Validators.minLength(2)]],
    });

    this.formModel = this._formBuilder.group({
      name: [null, [Validators.required, Validators.maxLength(100), Validators.minLength(2)]],
      marqueId: [null, [Validators.required,]],
    });

    this.formMarque = this._formBuilder.group({
      name: [null, [Validators.required, Validators.maxLength(50), Validators.minLength(2)]],
      typeArticleId: [null, [Validators.required,]],
    })

    this.caracteristique = {
      modelId: null,
      hasStockage: false,
      hasCouleur: false,
      hasNombreDeSim: false,
      hasImei: false,
      hasParticularite: false,
      hasEtat: false,
      hasProcesseurs: false,
      hasTailleEcran: false,
      hasRam: false,
      hasQualite: false,
      hasType: false,
      hasCapacite: false,
      hasCaracteristic: false,
      hasPuissance: false,
      hasCamera: false,
    }

    this.formCaracteristique = this._formBuilder.group({
      modelId: [null, [Validators.required,]],
      hasStockage: [false],
      hasCouleur: [false],
      hasNombreDeSim: [false],
      hasImei: [false],
      hasParticularite: [false],
      hasEtat: [false],
      hasProcesseurs: [false],
      hasTailleEcran: [false],
      hasRam: [false],
      hasQualite: [false],
      hasType: [false],
      hasCapacite: [false],
      hasCaracteristic: [false],
      hasPuissance: [false],
      hasCamera: [false],
    })

    this.formProduit = this._formBuilder.group({
      modelId: [null, Validators.required],
      caracteristic: [null],
      processeurs: [null],
      tailleEcran : [null],
      ram: [null],
      qualite : [null],
      camera : [null],
      capacite : [null],
      puissance : [null],
      nombreDeSim : [null],
      stockageId : [undefined],
      couleurId : [undefined],
      particulariteId : [undefined],
      etatId : [undefined],
      position: [null],
      typeId : [undefined],
      imei : [null],
    })
  }

  ngOnInit(): void {
    this.getCaracteristiques();
    this.getCouleurs();
    this.getEtats();
    this.getMarques();
    this.getModels();
    this.getParticularites();
    this.getStockages();
    this.getTypeArticles();
    this.getTypes();
  }

  getTypeArticles(){
    this._kadaService.getTypeArticleListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listTypeArticle = v.results;
    });
  }

  getMarques(){
    this._kadaService.getMarqueListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listMark = v.results;
    })
  }

  getModels(){
    this._kadaService.getModelListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listModel = v.results;
    })
  }

  getCaracteristiques(){
    this._kadaService.getCaracteristiqueListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listCaracteristique = v.results;
    })
  }

  getStockages(){
    this._kadaService.getStockageListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listStockage = v.results;
    })
  }

  getCouleurs(){
    this._kadaService.getCouleurListPage(SearchDTO.fromJS({
      pageIndex : -1, filters:{}
    })).subscribe(v =>{
      this.listCouleur = v.results;
    })
  }

  getParticularites(){
    this._kadaService.getParticulariteListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listParticularite = v.results;
    })
  }

  getEtats(){
    this._kadaService.getEtatListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listEtat = v.results;
    })
  }

  getTypes(){
    this._kadaService.getTypeListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{}
    })).subscribe(v =>{
      this.listType = v.results;
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

  saveTypeArticle(){
    if (this.formTypeArticle.valid) {
      this.showSpinner = true;
        const data = { ...this.formTypeArticle.value };
        this._kadaService.createTypeArticle(data)
          .subscribe({
            next: (response) => {
              this.showSpinner = false;
              this.getTypeArticles()
              this._cd.markForCheck()
              this._toastr.success("Type d'article ajouté avec succès!");
            },
            error: (err) => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
            },
            complete: () => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this.stepper.next();
            }
          })
      }else{
        this._toastr.error('Error ! Veillez vérifier vos champs');
      }
  }

  saveMarque(){
    if (this.formMarque.valid) {
      this.showSpinner = true;
        const data = { ...this.formMarque.value };
        this._kadaService.createMarque(data)
          .subscribe({
            next: (response) => {
              this.showSpinner = false;
              this.getMarques();
              this._cd.markForCheck();
              this._toastr.success("Marque ajoutée avec succès!");
            },
            error: (err) => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
            },
            complete: () => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this.stepper.next();
            }
          })
       }else{
        this._toastr.error('Error ! Veillez vérifier vos champs');
      }
  }

  saveModel(){
    if (this.formModel.valid) {
      this.showSpinner = true;
        const data = { ...this.formModel.value };
        this._kadaService.createModel(data)
          .subscribe({
            next: (response) => {
              this.showSpinner = false;
              this.getModels();
              this._cd.markForCheck()
              this._toastr.success("Model ajouté avec succès!");
            },
            error: (err) => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
            },
            complete: () => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this.stepper.next();
            }
          })
       }else{
        this._toastr.error('Error ! Veillez vérifier vos champs');
      }
  }

  saveCaracteristique(){
    if (this.formCaracteristique.valid) {
      this.showSpinner = true;
        const data = { ...this.formCaracteristique.value };
        this._kadaService.createCaracteristique(data)
          .subscribe({
            next: (response) => {
              this.showSpinner = false;
              this.getCaracteristiques();
              this._cd.markForCheck()
              this._toastr.success("Caractéristique ajoutée avec succès!");
            },
            error: (err) => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
            },
            complete: () => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this.stepper.next();
            }
          })
       }else{
        this._toastr.error('Error ! Veillez vérifier vos champs');
      }
  }

  saveProduit(){
    if (this.formProduit.valid) {
      this.showSpinner = true;
        const data = CreateArticleCommand.fromJS({ ...this.formProduit.value });
        data.caracteristiqueId = this.caracteristiqueId
        console.log(data)
        this._kadaService.createArticle(data)
          .subscribe({
            next: (response) => {
              this.showSpinner = false;
              this.formProduit.reset();
              this._cd.markForCheck();
              this._toastr.success("Produit ajoutée avec succès!");
            },
            error: (err) => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this._toastr.error(`Error! Veuillez vérifier vos champs puis réessayer!\n ${err.title}`);
            },
            complete: () => {
              this.showSpinner = false;
              this._cd.markForCheck()
              this.stepper.next();
            }
          })
       }else{
        this._toastr.error('Error ! Veillez vérifier vos champs');
      }
  }

  getCaracteristique($event){
    this._kadaService.getCaracteristiqueListPage(SearchDTO.fromJS({
      pageIndex:-1, filters:{
        model: $event.value
      }
    })).subscribe(v =>{
      this.caracteristique = v.results[0];
      this.caracteristiqueId = this.caracteristique.id
      this._cd.markForCheck()
      this.addValidator(this.formProduit);
      this._cd.markForCheck()
    })
  }
}
