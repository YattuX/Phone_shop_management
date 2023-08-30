import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog'
import { AppRoutingModule } from './app-routing.module';
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

import { AppComponent } from './app.component';
import { FooterComponent } from './shared/components/layouts/footer/footer.component';
import { InfoDialog } from './shared/components/dialogs/info/info.dialog';
import { FullComponent } from './shared/components/layouts/full/full.component';
import { AppBreadcrumbComponent } from './shared/components/layouts/breadcrumb/breadcrumb.component';
import { AppBlankComponent } from './shared/components/layouts/blank/blank.component';
import { SpinnerComponent } from './shared/spinner/spinner.component';
import { SidebarComponent } from './shared/components/layouts/sidebar/sidebar.component';
import { HeaderComponent } from './shared/components/layouts/header/header.component';
import { AuthModule } from './modules/auth/auth.module';
import { DashboardsModule } from './shared/components/dashboards/dashboards.module';
import { BreadcrumbCarouselComponent } from './shared/components/layouts/breadcrumb/breadcrumb-carousel/breadcrumb-carousel.component';
import { BreadcrumbNavigationComponent } from './shared/components/layouts/breadcrumb/breadcrumb-navigation/breadcrumb-navigation.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    InfoDialog,
    SidebarComponent,
    FullComponent,
    AppBreadcrumbComponent,
    AppBlankComponent,
    SpinnerComponent,
    HeaderComponent,
    BreadcrumbCarouselComponent,
    BreadcrumbNavigationComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatDialogModule,
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
    AuthModule,
    DashboardsModule,
    MatSlideToggleModule,
    MatCheckboxModule
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
