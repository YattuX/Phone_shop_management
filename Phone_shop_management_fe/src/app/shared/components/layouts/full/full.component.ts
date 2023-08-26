import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-full',
  templateUrl: './full.component.html'
})
export class FullComponent implements OnInit {
  openedSideNav?: boolean;

  constructor(private breakpointObserver: BreakpointObserver,) {
        
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
}
