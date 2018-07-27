import { Bike } from './models/bike';
import { User } from './user';
import { BikeIds } from './bike-ids';
import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private http: HttpClient) { }
  apiBaseUrl = "http://bike-hack.azurewebsites.net";
  getBikes = "/bikes";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  getAllBikeIds(){
    return this.http.get(this.apiBaseUrl+this.getBikes, this.httpOptions);
  }

  getAllBikes(ids) {
    let bikeList = [];
    ids.forEach(id => {
      let bike = this.http.get<Bike>(this.apiBaseUrl + "/bikes/" + id, this.httpOptions).subscribe(bike => {
        bikeList.push(bike);
      });
    });

    return bikeList;
  }

  registerUser(user: User) {
    return this.http.post(this.apiBaseUrl+"/users", user, this.httpOptions);
  }

  getUser(userId) {
    let output = new User;
    this.http.get<User>(this.apiBaseUrl+"/users/"+userId, this.httpOptions).subscribe(user => { output = user; });
    return output;
  }

  getUserTrips(userId) {

  }

}

