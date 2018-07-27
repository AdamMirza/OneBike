import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'biker-clock-stat',
  templateUrl: './biker-clock-stat.component.html',
  styleUrls: ['./biker-clock-stat.component.css']
})
export class BikerClockStatComponent implements OnInit {
  time = 2.4;
  constructor() { }

  ngOnInit() {
  }

}
