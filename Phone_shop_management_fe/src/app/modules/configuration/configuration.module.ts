import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListConfigComponent } from './components/list-config/list-config.component';
import { ConfigurationRoutingModule } from './configuration-routing.module';
import { TypeArticleComponent } from './components/type-article/type-article.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TypeArticleDialog } from './components/type-article/type-article.dialog';
import { MarqueComponent } from './components/marque/marque.component';
import { MarqueDialog } from './components/marque/marque.dialog';
import { ModeleComponent } from './components/modele/modele.component';
import { ModeleDialog } from './components/modele/modele.dialog';
import { CaracteristiqueComponent } from './components/caracteristique/caracteristique.component';
import { CaracteristiqueDialog } from './components/caracteristique/caracteristique.dialog';
import { CouleurComponent } from './components/couleur/couleur.component';
import { CouleurDialog } from './components/couleur/couleur.dialog';



@NgModule({
  declarations: [
    ListConfigComponent,
    TypeArticleComponent,
    TypeArticleDialog,
    MarqueComponent,
    MarqueDialog,
    ModeleComponent,
    ModeleDialog,
    CaracteristiqueComponent,
    CaracteristiqueDialog,
    CouleurComponent,
    CouleurDialog
  ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule,
    SharedModule
  ]
})
export class ConfigurationModule { }
