import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListConfigComponent } from './components/list-config/list-config.component';
import { ConfigurationRoutingModule } from './configuration-routing.module';
import { TypeArticleComponent } from './components/type-article/type-article.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TypeArticleDialog } from './components/type-article/type-article.dialog';



@NgModule({
  declarations: [
    ListConfigComponent,
    TypeArticleComponent,
    TypeArticleDialog
  ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule,
    SharedModule
  ]
})
export class ConfigurationModule { }
