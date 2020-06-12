import { Collection, QueryModel } from '@caiu/library';

export class Carrier {
  id = 0;
  name = '';
  get src(): string {
    switch (this.id) {
      case 1:
        return 'assets/carriers/diamond_logistics_logo.jpg';
      case 2:
        return 'assets/carriers/warren.png';
      case 3:
        return 'assets/carriers/ats.png';
    }
  }
}

export class Carriers extends Collection<Carrier> {
  constructor() {
    super(Carrier);
  }
}

export class CarriersQuery extends QueryModel<Carrier> {

}
