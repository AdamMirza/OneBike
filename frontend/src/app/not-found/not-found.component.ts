import { Router } from '@angular/router';
import { NavbarComponent } from './../navbar/navbar.component';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {

  constructor(private router: Router) {
    this.router.navigateByUrl('/app');
  }

  ngOnInit() {
    
  }

}
