import { RegisterNavbarComponent } from './../register-navbar/register-navbar.component';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'congrats',
  templateUrl: './congrats.component.html',
  styleUrls: ['./congrats.component.css']
})
export class CongratsComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  go() {
    this.router.navigateByUrl('/app');
  }
}
