import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'psl-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent implements OnInit {

  colorScheme = {
    domain: ['#FFDE00', '#367C2B']
  };
  data = [
    {
      name: 'Compact - 1 Series',
      series: [
        {
          name: 'In Stock',
          value: 10000
        },
        {
          name: 'Ordered',
          value: 12000
        }
      ]
    },
    {
      name: 'Compact - 2 Series',
      series: [
        {
          name: 'In Stock',
          value: 15000
        },
        {
          name: 'Ordered',
          value: 2000
        }
      ]
    },
    {
      name: 'Compact - 3 Series',
      series: [
        {
          name: 'In Stock',
          value: 5000
        },
        {
          name: 'Ordered',
          value: 2000
        }
      ]
    },
    {
      name: 'Compact - 4 Series',
      series: [
        {
          name: 'In Stock',
          value: 30000
        },
        {
          name: 'Ordered',
          value: 12000
        }
      ]
    },
    {
      name: 'Row Crop - 6 Series',
      series: [
        {
          name: 'In Stock',
          value: 19000
        },
        {
          name: 'Ordered',
          value: 13000
        }
      ]
    },
    {
      name: 'Row Crop - 7 Series',
      series: [
        {
          name: 'In Stock',
          value: 15000
        },
        {
          name: 'Ordered',
          value: 10000
        }
      ]
    },
    {
      name: 'Row Crop - 8 Series',
      series: [
        {
          name: 'In Stock',
          value: 5000
        },
        {
          name: 'Ordered',
          value: 4000
        }
      ]
    },
    {
      name: '5075GL',
      series: [
        {
          name: 'In Stock',
          value: 20000
        },
        {
          name: 'Ordered',
          value: 5000
        }
      ]
    },
    {
      name: '5090EL',
      series: [
        {
          name: 'In Stock',
          value: 18000
        },
        {
          name: 'Ordered',
          value: 3000
        }
      ]
    },
    {
      name: '5100ML',
      series: [
        {
          name: 'In Stock',
          value: 10000
        },
        {
          name: 'Ordered',
          value: 15000
        }
      ]
    },
    {
      name: '5115ML',
      series: [
        {
          name: 'In Stock',
          value: 7000
        },
        {
          name: 'Ordered',
          value: 3000
        }
      ]
    },
    {
      name: '5125ML',
      series: [
        {
          name: 'In Stock',
          value: 4000
        },
        {
          name: 'Ordered',
          value: 15000
        }
      ]
    },
    {
      name: 'Utility - 5E',
      series: [
        {
          name: 'In Stock',
          value: 16000
        },
        {
          name: 'Ordered',
          value: 8000
        }
      ]
    },
    {
      name: 'Utility - 5M',
      series: [
        {
          name: 'In Stock',
          value: 2000
        },
        {
          name: 'Ordered',
          value: 13000
        }
      ]
    },
    {
      name: 'Utility - 5R',
      series: [
        {
          name: 'In Stock',
          value: 8000
        },
        {
          name: 'Ordered',
          value: 20000
        }
      ]
    },
    {
      name: 'Utility - 6E',
      series: [
        {
          name: 'In Stock',
          value: 10000
        },
        {
          name: 'Ordered',
          value: 4000
        }
      ]
    },
    {
      name: 'Utility - 6M',
      series: [
        {
          name: 'In Stock',
          value: 20000
        },
        {
          name: 'Ordered',
          value: 15000
        }
      ]
    },
    {
      name: 'Utility - 6R',
      series: [
        {
          name: 'In Stock',
          value: 20000
        },
        {
          name: 'Ordered',
          value: 5000
        }
      ]
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

  onSelect(event) {
    console.log(event);
  }

}
