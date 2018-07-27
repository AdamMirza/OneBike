import { Router } from '@angular/router';
import { User } from './../user';
import { HttpService } from './../http.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SidebarComponent } from './../sidebar/sidebar.component';
import { RegisteredUsersService } from './../registered-users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userImageUrl = "./../assets/img/profile.png";

  constructor(private router:Router, private rus:RegisteredUsersService, private http:HttpService) { }

  ngOnInit() {
    let user = new User;
    //user = this.http.getUser("satyan@microsoft.com");
    //this.userImageUrl = user.profileImageUrl;
  }

  show:boolean = false;
  
  toggleCollapse() {
    this.show = !this.show
  }

  redirect() {
    this.router.navigateByUrl("/demo");
  }

}
