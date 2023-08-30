import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import {FormsModule} from '@angular/forms';
@Component({
  selector: 'app-full',
  templateUrl: './full.component.html'
})
export class FullComponent implements OnInit {
go() {
console.log(this.blue);

}
  openedSideNav?: boolean;
  dir = 'ltr';
  dark = false;
  minisidebar = false;
  boxed = false;
  horizontal = false;

  green = false;
  blue = false;
  danger:any = false;
  showHide = false;
  url = '';
  sidebarOpened = false;
  status = false;

  public showSearch = false;
  constructor(private breakpointObserver: BreakpointObserver,) {
    this.dark = false;
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
  
  clickEvent(): void {
    this.status = !this.status;
  }

  darkClick() {
    // const body = document.getElementsByTagName('body')[0];
    // this.dark = this.dark;
    const body = document.getElementsByTagName('body')[0];
    body.classList.toggle('dark');
    // if (this.dark)
    // else
    // 	body.classList.remove('dark');
    // this.dark = this.dark;
    // body.classList.toggle('dark');
    // this.dark = this.dark;
  }
}
