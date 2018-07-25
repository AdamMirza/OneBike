import { RegisteredUsersService } from './../registered-users.service';
import { Router } from '@angular/router';
import { TextAreaComponent } from './../text-area/text-area.component';
import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, AfterViewInit {
  homeBlock = false; // gets email
  contentBlock = false; // shows EULAs
  iconOne = false;
  iconTwo = false;
  iconThree = false;
  emailBlock = false; // show email on top right

  email = "";
  h3 = "";
  h4 = "";

  constructor(private elementRef: ElementRef, private router:Router, public rus: RegisteredUsersService) { }

  ngOnInit() {
    this.homeBlock=true;
  }

  ngAfterViewInit() {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#ffffff';
  }

  process(email) {
    this.email = email.viewModel;
    this.homeBlock = false;
    this.contentBlock = true;
    this.iconOne = true;
    this.emailBlock = true;

    this.h3 = "Follow the rules of the road";
    this.h4 = "Share the road with cars and follow the street laws in your area!";
  }

  secondBlock() {
    this.iconOne = false;
    this.iconTwo = true;
    this.h3 = "Be Safe";
    this.h4 = "Be aware of your surroundings and always wear a helmet!";
  }

  thirdBlock() {
    this.iconTwo = false;
    this.iconThree = true;
    this.h3 = "Yield to pedestrians";
    this.h4 = "Make smart decisions when biking around pedestrians!";
  }

  finish() {
    this.router.navigateByUrl('/congrats');
    this.rus.users.push(this.email);
    this.rus.currentUser = this.email;
  }

}
