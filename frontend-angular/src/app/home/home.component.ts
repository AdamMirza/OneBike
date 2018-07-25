import { LoginComponent } from './../login/login.component';
import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';


@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  title = "MS OneBike"
  constructor(private elementRef: ElementRef) { }

  ngOnInit() {
    
  }

  ngAfterViewInit() {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#00A4EF';
  }

}
