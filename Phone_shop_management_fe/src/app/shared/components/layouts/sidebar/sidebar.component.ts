import { Component, OnInit } from '@angular/core';
import { MenuItems } from 'src/app/core/models/interfaces';
import { MENU_ITEMS } from 'src/app/shared/global/menu-items';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  menuItems:MenuItems[];
  constructor() { 
    this.menuItems = MENU_ITEMS;
   }
}


