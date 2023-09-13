import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',

  styleUrls: ['./breadcrumb.css'],
})
export class AppBreadcrumbComponent {
  @Input() Title: string = ''

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
  ) { }

  ngOnInit(): void {
    this._router.events
      .pipe()
      .subscribe(() => {
        const route = this.getLastChild(this._activatedRoute);
        this.Title = route.snapshot.data['title'];
      })

  }

  private getLastChild(route: ActivatedRoute): ActivatedRoute {
    let lastChild = route;
    while (lastChild.firstChild) {
      lastChild = lastChild.firstChild;
    }
    return lastChild;
  }
}
