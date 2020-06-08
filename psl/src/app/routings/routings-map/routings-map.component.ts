import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { build } from '@caiu/library';
import {
  rubberBandAnimation
} from 'angular-animations';

import { ImageOverlay } from '../../shared/models';

@Component({
  selector: 'psl-routings-map',
  templateUrl: './routings-map.component.html',
  styleUrls: ['./routings-map.component.scss'],
  animations: [
    rubberBandAnimation()
  ]
})
export class RoutingsMapComponent implements OnInit {

  @ViewChild('map') mapEl: ElementRef;
  animationState = false;
  animationWithState = false;
  images: ImageOverlay[] = [
    build(ImageOverlay, {
      src: 'assets/building-psl.png',
      height: 60,
      top: 30,
      left: 82
    }),
    build(ImageOverlay, {
      src: 'assets/building-john-deere.png',
      height: 80,
      top: 28,
      left: 59
    }),
    build(ImageOverlay, {
      src: 'assets/dealers/dealer-shoppas.png',
      height: 50,
      top: 71,
      left: 46
    }),
    build(ImageOverlay, {
      src: 'assets/dealers/dealer-deer-country.png',
      height: 50,
      top: 25,
      left: 85
    }),
    build(ImageOverlay, {
      src: 'assets/dealers/dealer-campbell.png',
      height: 50,
      top: 15,
      left: 15
    }),
    build(ImageOverlay, {
      src: 'assets/carriers/truck-diamond.png',
      height: 25,
      top: 15,
      left: 30
    }),
    build(ImageOverlay, {
      src: 'assets/carriers/truck-ats.png',
      height: 25,
      top: 30,
      left: 30
    }),
    build(ImageOverlay, {
      src: 'assets/carriers/truck-warren.png',
      height: 25,
      top: 45,
      left: 30
    })
  ];
  mapHeight = 0;
  mapWidth = 0;

  constructor() { }

  ngOnInit(): void {
    setTimeout(() => {
      this.animate();
    }, 0);
  }

  ngAfterViewInit() {
    console.dir(this.mapEl.nativeElement);
    this.mapHeight = this.mapEl.nativeElement.clientHeight;
    this.mapWidth = this.mapEl.nativeElement.clientWidth;
  }

  animate() {
    this.animationState = false;
    setTimeout(() => {
      this.animationState = true;
      this.animationWithState = !this.animationWithState;
    }, 1);
  }

}
