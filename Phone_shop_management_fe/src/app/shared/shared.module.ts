import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog'
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import {MatBadgeModule} from '@angular/material/badge';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { FooterComponent } from './components/layouts/footer/footer.component';
import { InfoDialog } from './components/dialogs/info/info.dialog';
import { SidebarComponent } from './components/layouts/sidebar/sidebar.component';
import { FullComponent } from './components/layouts/full/full.component';
import { AppBreadcrumbComponent } from './components/layouts/breadcrumb/breadcrumb.component';
import { AppBlankComponent } from './components/layouts/blank/blank.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { HeaderComponent } from './components/layouts/header/header.component';
import { BreadcrumbCarouselComponent } from './components/layouts/breadcrumb/breadcrumb-carousel/breadcrumb-carousel.component';
import { BreadcrumbNavigationComponent } from './components/layouts/breadcrumb/breadcrumb-navigation/breadcrumb-navigation.component';


import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UsersModule } from '../modules/users/users.module';
import { AuthModule } from '../modules/auth/auth.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    FooterComponent,
    InfoDialog,
    SidebarComponent,
    FullComponent,
    AppBreadcrumbComponent,
    AppBlankComponent,
    HeaderComponent,
    BreadcrumbCarouselComponent,
    BreadcrumbNavigationComponent,
    SpinnerComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    RouterModule,
    MatIconModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatBadgeModule,
    MatTooltipModule,
    MatCardModule,
    MatGridListModule,
    MatFormFieldModule,
    MatInputModule,
    MatSlideToggleModule,
    MatCheckboxModule,
    UsersModule,
    AuthModule,
    FormsModule,

  ],
  exports:[
    SpinnerComponent,
    AppBreadcrumbComponent,
    HeaderComponent,
    BreadcrumbCarouselComponent,
    BreadcrumbNavigationComponent,
    FooterComponent,
    InfoDialog,
    SidebarComponent,
    FullComponent,
    AppBreadcrumbComponent,
    AppBlankComponent,
  ],
  providers: [],
})
export class SharedModule { }
