import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MS OneBike';
  loggedIn: boolean;
  
  constructor() {
    this.loggedIn = false;
  }

  latitude = 51.678418;
  longitude = 7.809007;
  locationChosen = false;
  loc_lat = this.latitude;
  loc_lng = this.longitude;

  onChoseLocation(event) {
    this.loc_lat = event.coords.lat;
    this.loc_lng = event.coords.lng;
    this.locationChosen = true;
  }
}
