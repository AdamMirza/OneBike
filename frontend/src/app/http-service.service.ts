import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpServiceService {
  
  apiBaseUrl = "http://bike-hack.azurewebsites.net";
  getBikes = "/bikes";

  constructor(private http: HttpClient) { }

  getSingleBikeLocation(){
    return this.http.get(this.apiBaseUrl+this.getBikes);
  }

}
