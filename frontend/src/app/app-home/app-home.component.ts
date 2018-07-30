import { RegisteredUsersService } from './../registered-users.service';
import { NavbarComponent } from './../navbar/navbar.component';
import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-app-home',
  templateUrl: './app-home.component.html',
  styleUrls: ['./app-home.component.css']
})
export class AppHomeComponent implements OnInit, AfterViewInit {

  constructor(private elementRef: ElementRef, private rus: RegisteredUsersService) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#ffffff';
  }
}
