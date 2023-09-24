import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListConfigComponent } from './components/list-config/list-config.component';
import { TypeArticleComponent } from './components/type-article/type-article.component';

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
            }
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ConfigurationRoutingModule { }