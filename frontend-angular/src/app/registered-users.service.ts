import { Injectable } from '@angular/core';

@Injectable()
export class RegisteredUsersService {
  public users = ["hello@microsoft.com", "satyan@microsoft.com"];
  public currentUser: string;
  public isUser = false;
  
  constructor() {
    console.log(this.currentUser == null);
    if (this.currentUser) {
      this.isUser = false;
    } else {
      this.isUser = true;
    }
  }
}
