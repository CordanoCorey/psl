import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'psl-carriers-market-share',
  templateUrl: './carriers-market-share.component.html',
  styleUrls: ['./carriers-market-share.component.scss']
})
export class CarriersMarketShareComponent implements OnInit {

  data: any[] = [];
  colorScheme = {
    domain: ['#054782', '#DE111A', '#E6B81B']
  };
  _mode: 'TOTAL_DOLLARS' | 'TOTAL_ROUTES' = 'TOTAL_ROUTES';

  constructor() {
    this.resetData();
  }

  set mode(value: 'TOTAL_DOLLARS' | 'TOTAL_ROUTES') {
    this._mode = value;
    this.resetData();
  }

  get mode(): 'TOTAL_DOLLARS' | 'TOTAL_ROUTES' {
    return this._mode;
  }

  get label(): string {
    return this.mode === 'TOTAL_DOLLARS' ? 'Total Cost ($)' : 'Total Routings (#)';
  }

  ngOnInit() {

  }

  resetData() {
    this.data = this.mode === 'TOTAL_DOLLARS' ? [
      {
        name: 'Diamond',
        value: 32545
      },
      {
        name: 'ATS',
        value: 12950
      },
      {
        name: 'Warren',
        value: 28485
      }
    ] : [
        {
          name: 'Diamond',
          value: 44
        },
        {
          name: 'ATS',
          value: 36
        },
        {
          name: 'Warren',
          value: 20
        }
      ];
  }

  onSelect(data): void {
    // console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data): void {
    // console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data): void {
    // console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }

}
