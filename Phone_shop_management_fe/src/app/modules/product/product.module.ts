import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './components/appareil/product-list.component.tab';
import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddProduct } from './components/addProduct';
import { PieceComponent } from './components/piece/piece.component.tab';
import { AccessoirComponent } from './components/accessoir/accessoir.component.tab';
import { TelephoneComponent } from './components/appareil/telephone/telephone.component';
import { TabletteComponent } from './components/appareil/tablette/tablette.component';
import { OrdinateurComponent } from './components/appareil/ordinateur/ordinateur.component';
import { PochetteComponent } from './components/accessoir/pochette/pochette.component';
import { AntiCasseComponent } from './components/accessoir/anti-casse/anti-casse.component';
import { NettoyageComponent } from './components/accessoir/nettoyage/nettoyage.component';
import { InstrumentComponent } from './components/accessoir/instrument/instrument.component';
import { ConnectiqueComponent } from './components/accessoir/connectique/connectique.component';
import { AppareilAccessoirComponent } from './components/accessoir/appareil-accessoir/appareil-accessoir.component';
import { EcranComponent } from './components/piece/ecran/ecran.component';
import { BatterieComponent } from './components/piece/batterie/batterie.component';
import { CameraComponent } from './components/piece/camera/camera.component';
import { HautParleurComponent } from './components/piece/haut-parleur/haut-parleur.component';
import { VitreComponent } from './components/piece/vitre/vitre.component';
import { NapeEtPaletteComponent } from './components/piece/nape-et-palette/nape-et-palette.component';
import { MicroEtVibreurComponent } from './components/piece/micro-et-vibreur/micro-et-vibreur.component';
import { CadreComponent } from './components/piece/cadre/cadre.component';
import { MoteurComponent } from './components/piece/moteur/moteur.component';
import { AutoCompleteComponent } from "../../shared/components/autocomplete/autocomplete.component";
import { ListProductComponent } from 'src/app/shared/components/list-product/list-product.component';




@NgModule({
    declarations: [
        ProductListComponent,
        AddProduct,
        PieceComponent,
        AccessoirComponent,
        TelephoneComponent,
        TabletteComponent,
        OrdinateurComponent,
        PochetteComponent,
        AntiCasseComponent,
        NettoyageComponent,
        InstrumentComponent,
        ConnectiqueComponent,
        AppareilAccessoirComponent,
        EcranComponent,
        BatterieComponent,
        CameraComponent,
        HautParleurComponent,
        VitreComponent,
        NapeEtPaletteComponent,
        MicroEtVibreurComponent,
        CadreComponent,
        MoteurComponent,
    ],
    imports: [
        CommonModule,
        ProductRoutingModule,
        SharedModule,
        AutoCompleteComponent
    ]
})
export class ProductModule { }
