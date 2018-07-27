import { BikerClockStatComponent } from './../biker-clock-stat/biker-clock-stat.component';
import { BikerSidebarStatComponent } from './../biker-sidebar-stat/biker-sidebar-stat.component';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  isOnNav = true;
  isOnStats = false;
  constructor() { }

  ngOnInit() {
  }

  goToStats() {
    this.isOnNav = false;
    this.isOnStats = true;
  }

  goToNav() {
    this.isOnStats = false;
    this.isOnNav = true;
  }

}
