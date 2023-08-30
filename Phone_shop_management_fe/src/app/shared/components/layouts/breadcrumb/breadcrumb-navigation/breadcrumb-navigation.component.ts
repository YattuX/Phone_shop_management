import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router, NavigationEnd, ActivatedRoute, Data } from '@angular/router';
import { filter, map, mergeMap } from 'rxjs/operators';
import { ThemePalette } from '@angular/material/core';
@Component({
  selector: 'app-breadcrumb-navigation',
  templateUrl: './breadcrumb-navigation.component.html',
  // styleUrls: ['./breadcrumb-navigation.component.scss']
})
export class BreadcrumbNavigationComponent {
// @Input() layout;
pageInfo: Data = Object.create(null);
primaryColor: ThemePalette;
constructor(
  private router: Router,
  private activatedRoute: ActivatedRoute,
  public titleService: Title,
) {
  this.router.events
    .pipe(filter((event) => event instanceof NavigationEnd))
    .pipe(map(() => this.activatedRoute))
    .pipe(
      map((route) => {
        while (route.firstChild) {
          route = route.firstChild;
        }
        return route;
      }),
    )
    .pipe(filter((route) => route.outlet === 'primary'))
    .pipe(mergeMap((route) => route.data))
    // tslint:disable-next-line - Disables all
    .subscribe((event) => {
      // tslint:disable-next-line - Disables all
      this.titleService.setTitle(event['title']);
      this.pageInfo = event;
    });
    this.primaryColor = 'primary'
}
}
