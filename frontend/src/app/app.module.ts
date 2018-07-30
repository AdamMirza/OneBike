import { HttpService } from './http.service';
import { RegisteredUsersService } from './registered-users.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AgmCoreModule } from '@agm/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { Component, OnInit } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { MapComponent } from './map/map.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AppHomeComponent } from './app-home/app-home.component';
import { RegisterComponent } from './register/register.component';
import { RegisterNavbarComponent } from './register-navbar/register-navbar.component';
import { TextAreaComponent } from './text-area/text-area.component';
import { CongratsComponent } from './congrats/congrats.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { BikerSidebarStatComponent } from './biker-sidebar-stat/biker-sidebar-stat.component';
import { BikerClockStatComponent } from './biker-clock-stat/biker-clock-stat.component';
import { MyStatsComponent } from './my-stats/my-stats.component';
import { DemoComponent } from './demo/demo.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MapComponent,
    HomeComponent,
    NotFoundComponent,
    NavbarComponent,
    AppHomeComponent,
    RegisterComponent,
    RegisterNavbarComponent,
    TextAreaComponent,
    CongratsComponent,
    SidebarComponent,
    BikerSidebarStatComponent,
    BikerClockStatComponent,
    MyStatsComponent,
    DemoComponent
  ],
  imports: [
    BrowserModule,
    AgmCoreModule.forRoot({
      apiKey:"AIzaSyAlX_mANDoLcznWuVOLDnHSvBHI0BWJ3uY"
    }),
    FormsModule,
    HttpModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '',         component: HomeComponent},
      { path: 'register', component: RegisterComponent},
      { path: 'app',      component: AppHomeComponent},
      { path: 'congrats', component: CongratsComponent},
      { path: 'demo',     component: DemoComponent},
      { path: '**',       component: NotFoundComponent}
    ])
  ],
  providers: [RegisteredUsersService, HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
