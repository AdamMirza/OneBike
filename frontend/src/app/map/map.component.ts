import { Bike } from './../models/bike';
import { BikeIds } from './../bike-ids';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpService } from './../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  constructor(private httpService:HttpService) { }

  bikeList = [];
  isBikeListLoaded = false;
  latitude = 47.6445161;
  longitude = -122.13681220000001;
  locationChosen = false;
  loc_lat = this.latitude;
  loc_lng = this.longitude;
  isLoading: boolean;

  ngOnInit() {
    let ids;
    this.httpService.getAllBikeIds().subscribe(ids => this.getBikeList(ids));
    this.isLoading = true;
  }

  ngAfterViewInit() {
    this.isLoading = false;
  }

  getBikeList(ids) {
    this.bikeList = this.httpService.getAllBikes(ids);
    this.isBikeListLoaded = true;
  }

  onChoseLocation(event) {
    this.loc_lat = event.coords.lat;
    this.loc_lng = event.coords.lng;
    this.locationChosen = true;

    this.httpService.getAllBikeIds().subscribe(data => console.log(data));
    console.log();
  }

}
