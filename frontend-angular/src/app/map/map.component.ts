import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  latitude = 47.6445161;
  longitude = -122.13681220000001;
  locationChosen = false;
  loc_lat = this.latitude;
  loc_lng = this.longitude;

  onChoseLocation(event) {
    this.loc_lat = event.coords.lat;
    this.loc_lng = event.coords.lng;
    this.locationChosen = true;
  }

}
