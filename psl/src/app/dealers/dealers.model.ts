import { Collection, QueryModel } from '@caiu/library';

export class Dealer {
  id = 0;
  name = '';

  get src(): string {
    switch (this.id) {
      case 1:
        return 'assets/dealers/deer-country.png';
      case 2:
        return 'assets/dealers/shoppas.jpg';
      case 3:
        return 'assets/dealers/campbell.jpg';
    }
    return null;
  }

  get logoSrc(): string {
    switch (this.id) {
      case 1:
        return 'assets/dealers/deer-country.png';
      case 2:
        return 'assets/dealers/shoppas.jpg';
      case 3:
        return 'assets/dealers/campbell.jpg';
    }
    return null;
  }
}

export class Dealers extends Collection<Dealer> {
  constructor() {
    super(Dealer);
  }
}

export class DealersQuery extends QueryModel<Dealer> {

}
