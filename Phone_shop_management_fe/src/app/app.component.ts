import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';
import { AuthService } from './shared/services/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent implements OnInit {
  title = 'Phone_repair_shops_Management';
  openedSideNav?: boolean;
  showTopBarAndSideBar: boolean = true;

  urlNotSideAndTopNav=['/404','/login'];

  constructor(
    private breakpointObserver: BreakpointObserver, 
    private _auth: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    ) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: any) => {
      
      if (this.urlNotSideAndTopNav.includes(event.url) || this.urlNotSideAndTopNav.includes(event.urlAfterRedirects)) {
        this.showTopBarAndSideBar = false; // Hide top bar and side bar for the 404 page
      } else {
        this.showTopBarAndSideBar = true; // Show top bar and side bar for other pages
      }
    });
  }

  ngOnInit(): void {
    this.breakpointObserver.observe([
      Breakpoints.Handset,
      // Breakpoints.Tablet,
      // Breakpoints.Web
    ]).subscribe(result => {
      this.openedSideNav = !result.matches;
    })
  }

  menuItems: MenuItems[] = [
    { title: "Utilisateurs", icon: "manage_accounts", link: "a", divider: false },
    { title: "Clients", icon: "people", link: "b", divider: false },
    { title: "Fournisseurs", icon: "shop", link: "c", divider: true },
    { title: "Articles", icon: "receipt", link: "products", divider: false },
    { title: "Stocks", icon: "store", link: "d", divider: false },
    { title: "Ventes", icon: "add_shopping_cart", link: "e", divider: true },
    { title: "Paiements", icon: "account_balance", link: "f", divider: true },
    { title: "Reparations", icon: "build", link: "g", divider: true },
    { title: "Configuration", icon: "settings", link: "h", divider: true }
  ];

  logout(){
    this._auth.logout();
    this.router.navigateByUrl('/login');
  }
  
}

export interface MenuItems {
  title: string;
  icon: string;
  link: string;
  divider?: boolean;
}

