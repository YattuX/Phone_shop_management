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
import { AuthGuard } from 'src/app/shared/services/auth.guard';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'appareil',
        pathMatch: 'full'
    },
    {
        path: 'appareil',
        component: ProductListComponent,
        canActivate:[AuthGuard],
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
                canActivate:[AuthGuard],
            },
            {
                path: 'tablette',
                component: TabletteComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'ordinateur',
                component: OrdinateurComponent,
                canActivate:[AuthGuard],
            }
        ]
    },
    {
        path: 'piece',
        component: PieceComponent,
        canActivate:[AuthGuard],
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
                canActivate:[AuthGuard],
            },
            {
                path: 'cadre',
                component: CadreComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'camera',
                component: CameraComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'ecran',
                component: EcranComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'haut_parleur',
                component: HautParleurComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'micro_et_vibreur',
                component: MicroEtVibreurComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'moteur',
                component: MoteurComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'nape_et_palette',
                component: NapeEtPaletteComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'vitre',
                component: VitreComponent,
                canActivate:[AuthGuard],
            }

        ]
    },
    {
        path: 'accessoir',
        component: AccessoirComponent,
        canActivate:[AuthGuard],
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
                component: AntiCasseComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'appreil_accessoir',
                component: AppareilAccessoirComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'connectique',
                component: ConnectiqueComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'instrument',
                component: InstrumentComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'netoyage',
                component: NettoyageComponent,
                canActivate:[AuthGuard],
            },
            {
                path: 'pochette',
                component: PochetteComponent,
                canActivate:[AuthGuard],
            },
        ]
    },
    {
        path: 'materiel',
        component: ProductListComponent,
        canActivate:[AuthGuard],
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
