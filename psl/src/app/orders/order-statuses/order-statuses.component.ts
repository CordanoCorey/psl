import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'psl-order-statuses',
  templateUrl: './order-statuses.component.html',
  styleUrls: ['./order-statuses.component.scss']
})
export class OrderStatusesComponent implements OnInit {

  single: any[];

  colorScheme = {
    domain: ['#F5B700', '#00A1E4', '#DC0073', '#04E762']
  };

  constructor() {
    Object.assign(this, {
      single: [
        {
          name: 'Submitted',
          value: 9
        },
        {
          name: 'Processing',
          value: 20
        },
        {
          name: 'In Transit',
          value: 42
        },
        {
          name: 'Completed',
          value: 29
        }
      ]
    });
  }

  ngOnInit() {

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
