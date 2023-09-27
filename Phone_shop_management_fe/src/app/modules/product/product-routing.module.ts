import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/appareil/product-list.component.tab';
import { TelephoneComponent } from './components/appareil/telephone/telephone.component';
import { TabletteComponent } from './components/appareil/tablette/tablette.component';
import { OrdinateurComponent } from './components/appareil/ordinateur/ordinateur.component';
import { BatterieComponent } from './components/piece/batterie/batterie.component';
import { CadreComponent } from './components/piece/cadre/cadre.component';
import { CameraComponent } from './components/piece/camera/camera.component';
import { EcranComponent } from './components/piece/ecran/ecran.component';
import { HautParleurComponent } from './components/piece/haut-parleur/haut-parleur.component';
import { MicroEtVibreurComponent } from './components/piece/micro-et-vibreur/micro-et-vibreur.component';
import { MoteurComponent } from './components/piece/moteur/moteur.component';
import { NapeEtPaletteComponent } from './components/piece/nape-et-palette/nape-et-palette.component';
import { VitreComponent } from './components/piece/vitre/vitre.component';
import { AntiCasseComponent } from './components/accessoir/anti-casse/anti-casse.component';
import { AppareilAccessoirComponent } from './components/accessoir/appareil-accessoir/appareil-accessoir.component';
import { ConnectiqueComponent } from './components/accessoir/connectique/connectique.component';
import { InstrumentComponent } from './components/accessoir/instrument/instrument.component';
import { NettoyageComponent } from './components/accessoir/nettoyage/nettoyage.component';
import { PochetteComponent } from './components/accessoir/pochette/pochette.component';
import { PieceComponent } from './components/piece/piece.component.tab';
import { AccessoirComponent } from './components/accessoir/accessoir.component.tab';
import { AddProduct } from './components/addProduct';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'appareil',
        pathMatch: 'full'
    },
    {
        path: 'appareil',
        component: ProductListComponent,
        data: {
            title: 'Liste des articles'
        },
        children: [
            {
                path: '',
                redirectTo: 'telephone',
                pathMatch: 'full'
            },
            {
                path: 'telephone',
                component: TelephoneComponent,
            },
            {
                path: 'tablette',
                component: TabletteComponent,
            },
            {
                path: 'ordinateur',
                component: OrdinateurComponent,
            }
        ]
    },
    {
        path: 'piece',
        component: PieceComponent,
        data: {
            title: 'Liste des pièces'
        },
        children: [
            {
                path: '',
                redirectTo: 'batterie',
                pathMatch: 'full'
            },
            {
                path: 'batterie',
                component: BatterieComponent,
            },
            {
                path: 'cadre',
                component: CadreComponent
            },
            {
                path: 'camera',
                component: CameraComponent
            },
            {
                path: 'ecran',
                component: EcranComponent
            },
            {
                path: 'haut_parleur',
                component: HautParleurComponent
            },
            {
                path: 'micro_et_vibreur',
                component: MicroEtVibreurComponent
            },
            {
                path: 'moteur',
                component: MoteurComponent
            },
            {
                path: 'nape_et_palette',
                component: NapeEtPaletteComponent
            },
            {
                path: 'vitre',
                component: VitreComponent
            }

        ]
    },
    {
        path: 'accessoir',
        component: AccessoirComponent,
        data: {
            title: 'Liste des accessoirs'
        },
        children: [
            {
                path: '',
                redirectTo: 'anti_cass',
                pathMatch: 'full'
            },
            {
                path: 'anti_cass',
                component: AntiCasseComponent
            },
            {
                path: 'appreil_accessoir',
                component: AppareilAccessoirComponent
            },
            {
                path: 'connectique',
                component: ConnectiqueComponent
            },
            {
                path: 'instrument',
                component: InstrumentComponent
            },
            {
                path: 'netoyage',
                component: NettoyageComponent
            },
            {
                path: 'pochette',
                component: PochetteComponent
            },
        ]
    },
    {
        path: 'materiel',
        component: ProductListComponent,
        data: {
            title: 'Liste matériels'
        }
    },
    {
        path: 'add-produit',
        component: AddProduct,
        data: {
            title: 'Liste matériels'
        }
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ProductRoutingModule { }
