import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  tiles: Tile[] = [];

  //t: Tile = { title: '', link: '', icon: '', description: '' }
  t0: Tile = { title: 'Results', link: '/results', icon: 'check', description: 'View results' }
  t1: Tile = { title: 'Attendance', link: '/attendance', icon: 'people', description: "Take attendance" }

  constructor() {
    this.tiles.push(this.t0);
    this.tiles.push(this.t1);
   }

  ngOnInit() {
  }

}

export interface Tile {
  title: string;
  link: string;
  icon: string;
  description: string;
}