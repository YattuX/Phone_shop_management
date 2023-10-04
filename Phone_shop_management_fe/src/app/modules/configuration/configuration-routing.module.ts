import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListConfigComponent } from './components/list-config/list-config.component';
import { TypeArticleComponent } from './components/type-article/type-article.component';
import { MarqueComponent } from './components/marque/marque.component';
import { ModeleComponent } from './components/modele/modele.component';
import { CaracteristiqueComponent } from './components/caracteristique/caracteristique.component';
import { CouleurComponent } from './components/couleur/couleur.component';
import { AuthGuard } from 'src/app/shared/services/auth.guard';

const routes: Routes = [
    {
        path: '',
        children:[
            {
                path:'type_article',
                component:TypeArticleComponent,
                canActivate:[AuthGuard],
                data:{
                    title:"CONFIGURATION>TYPE D'ARTICLES"
                }
            },
            {
                path:'marque',
                component:MarqueComponent,
                canActivate:[AuthGuard],
                data:{
                    title:"CONFIGURATION>Marque"
                }
            },
            {
                path:'modele',
                component:ModeleComponent,
                data:{
                    title:"CONFIGURATION>Modèle"
                }
            },
            {
                path:'caracteristique',
                component:CaracteristiqueComponent,
                canActivate:[AuthGuard],
                data:{
                    title:"CONFIGURATION> caractéristique"
                }
            },
            {
                path:'couleur',
                component:CouleurComponent,
                canActivate:[AuthGuard],
                data:{
                    title:"CONFIGURATION>Couleur"
                }
            },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ConfigurationRoutingModule { }