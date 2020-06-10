import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'psl-timeframe-control',
  templateUrl: './timeframe-control.component.html',
  styleUrls: ['./timeframe-control.component.scss']
})
export class TimeframeControlComponent implements OnInit {

  @Input() timeframeId = 1;

  constructor() { }

  ngOnInit(): void {
  }

}
