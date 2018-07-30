import { HttpService } from './../http.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'biker-sidebar-stat',
  templateUrl: './biker-sidebar-stat.component.html',
  styleUrls: ['./biker-sidebar-stat.component.css']
})
export class BikerSidebarStatComponent implements OnInit {

  miles = 28;
  constructor(private httpService:HttpService) { }

  ngOnInit() {
    let user = this.httpService.getUser("satyan@microsoft.com");
  }

}
