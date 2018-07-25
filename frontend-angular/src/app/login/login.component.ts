import { RegisteredUsersService } from './../registered-users.service';
import { AppComponent } from './../app.component';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private rus: RegisteredUsersService) { }

  isValid = false;
  log(x) {
    //console.log(x);
    //console.log(x.viewModel);
  }

  submit(email) {
    this.rus.users.forEach(item => {
      if (item === email.viewModel) {
        this.isValid = true;
        this.rus.currentUser = item;
      }
    });

    if (this.isValid) {
      this.router.navigateByUrl('/app');
    }
  }

  register() {
    this.router.navigateByUrl('/register');
  }
  
  ngOnInit() {
  }
}
