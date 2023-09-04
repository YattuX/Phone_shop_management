import { Component, Input, OnInit } from '@angular/core';
import { BreadcrumbNavigationComponent } from './breadcrumb-navigation/breadcrumb-navigation.component'
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',

  styleUrls: ['./breadcrumb.css'],
})
export class AppBreadcrumbComponent {
@Input() Title : string = ''

constructor(
  private _activatedRoute : ActivatedRoute
){
}

  ngOnInit(): void {
    this.Title = this._activatedRoute.snapshot.routeConfig?.data?.['title']
  }
}
