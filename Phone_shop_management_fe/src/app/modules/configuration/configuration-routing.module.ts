import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListConfigComponent } from './components/list-config/list-config.component';
import { TypeArticleComponent } from './components/type-article/type-article.component';
import { MarqueComponent } from './components/marque/marque.component';
import { ModeleComponent } from './components/modele/modele.component';
import { CaracteristiqueComponent } from './components/caracteristique/caracteristique.component';

const routes: Routes = [
    {
        path: '',
        children:[
            {
                path:'type_article',
                component:TypeArticleComponent,
                data:{
                    title:"CONFIGURATION>TYPE D'ARTICLES"
                }
            },
            {
                path:'marque',
                component:MarqueComponent,
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
                data:{
                    title:"CONFIGURATION>caractéristique"
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