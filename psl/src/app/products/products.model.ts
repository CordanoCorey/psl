import { Collection } from '@caiu/library';

export class Product {
  id = 0;
  name = '';

  get imageSrc(): string {
    switch (this.id) {
      case 1:
        return 'assets/products/compact-1series.png';
      case 2:
        return 'assets/products/compact-2series.png';
      case 3:
        return 'assets/products/compact-3series.png';
      case 4:
        return 'assets/products/compact-4series.png';
      case 5:
        return 'assets/products/utility-5E.jpg';
      case 6:
        return 'assets/products/utility-5M.jpg';
      case 7:
        return 'assets/products/utility-5R.jpg';
      case 8:
        return 'assets/products/utility-6E.jpg';
      case 9:
        return 'assets/products/utility-6M.jpg';
      case 10:
        return 'assets/products/utility-6R.jpg';
      case 11:
        return 'assets/products/specialty-5075GL.png';
      case 12:
        return 'assets/products/specialty-5090EL.png';
      case 13:
        return 'assets/products/specialty-5100ML.png';
      case 14:
        return 'assets/products/specialty-5115ML.png';
      case 15:
        return 'assets/products/specialty-5125ML.png';
      case 16:
        return 'assets/products/rowcrop-6series.jpg';
      case 17:
        return 'assets/products/rowcrop-7series.jpg';
      case 18:
        return 'assets/products/rowcrop-8series.jpg';
      default:
        return 'assets/products/category-4wd.png';
    }
  }
}

export class Products extends Collection<Product> {
  constructor() {
    super(Product);
  }
}
