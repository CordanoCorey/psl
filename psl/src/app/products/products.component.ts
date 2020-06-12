import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'psl-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  tiles = [
    {
      id: 1,
      name: 'Compact 1 Series',
      src: 'assets/products/compact-1series.png',
      categoryName: 'Compact',
      rows: 1,
      cols: 1
    },
    {
      id: 2,
      name: 'Compact 2 Series',
      src: 'assets/products/compact-2series.png',
      categoryName: 'Compact',
      rows: 1,
      cols: 1
    },
    {
      id: 3,
      name: 'Compact 3 Series',
      src: 'assets/products/compact-3series.png',
      categoryName: 'Compact',
      rows: 1,
      cols: 1
    },
    {
      id: 4,
      name: 'Compact 4 Series',
      src: 'assets/products/compact-4series.png',
      categoryName: 'Compact',
      rows: 1,
      cols: 1
    },
    {
      id: 11,
      name: '5075GL',
      src: 'assets/products/specialty-5075GL.png',
      categoryName: 'Specialty',
      rows: 1,
      cols: 1
    },
    {
      id: 12,
      name: '5090EL',
      src: 'assets/products/specialty-5090EL.png',
      categoryName: 'Specialty',
      rows: 1,
      cols: 1
    },
    {
      id: 13,
      name: '5100ML',
      src: 'assets/products/specialty-5100ML.png',
      categoryName: 'Specialty',
      rows: 1,
      cols: 1
    },
    {
      id: 14,
      name: '5115ML',
      src: 'assets/products/specialty-5115ML.png',
      categoryName: 'Specialty',
      rows: 1,
      cols: 1
    },
    {
      id: 15,
      name: '5125ML',
      src: 'assets/products/specialty-5125ML.png',
      categoryName: 'Specialty',
      rows: 1,
      cols: 1
    },
    {
      id: 5,
      name: 'Utility 5E Series',
      src: 'assets/products/utility-5E.jpg',
      categoryName: 'Utility',
      rows: 1,
      cols: 1
    },
    {
      id: 6,
      name: 'Utility 5M Series',
      src: 'assets/products/utility-5M.jpg',
      categoryName: 'Utility',
      rows: 1,
      cols: 1
    },
    {
      id: 7,
      name: 'Utility 5R Series',
      src: 'assets/products/utility-5R.jpg',
      categoryName: 'Utility',
      rows: 1,
      cols: 1
    },
    {
      id: 8,
      name: 'Utility 6E Series',
      src: 'assets/products/utility-6E.jpg',
      categoryName: 'Utility',
      rows: 1,
      cols: 1
    },
    {
      id: 9,
      name: 'Utility 6M Series',
      src: 'assets/products/utility-6M.jpg',
      categoryName: 'Utility',
      rows: 1,
      cols: 1
    },
    {
      id: 10,
      name: 'Utility 6R Series',
      src: 'assets/products/utility-6R.jpg',
      categoryName: 'Utility',
      rows: 1,
      cols: 1
    },
    {
      id: 16,
      name: 'Row Crop 6 Series',
      src: 'assets/products/rowcrop-6series.jpg',
      categoryName: 'Row Crop',
      rows: 1,
      cols: 1
    },
    {
      id: 17,
      name: 'Row Crop 7 Series',
      src: 'assets/products/rowcrop-7series.jpg',
      categoryName: 'Row Crop',
      rows: 1,
      cols: 1
    },
    {
      id: 18,
      name: 'Row Crop 8 Series',
      src: 'assets/products/rowcrop-8series.jpg',
      categoryName: 'Row Crop',
      rows: 1,
      cols: 1
    },
    {
      id: 19,
      name: '4WD 80 Inch',
      src: 'assets/products/category-4wd.png',
      categoryName: '4WD',
      rows: 1,
      cols: 1
    },
    {
      id: 20,
      name: '4WD 80 Inch',
      src: 'assets/products/category-4wd.png',
      categoryName: '4WD',
      rows: 1,
      cols: 1
    },
    {
      id: 21,
      name: '4WD 80 Inch',
      src: 'assets/products/category-4wd.png',
      categoryName: '4WD',
      rows: 1,
      cols: 1
    }
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
