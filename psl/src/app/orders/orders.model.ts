import { Collection } from '@caiu/library';

export class Order {

}

export class Orders extends Collection<Order> {
  constructor() {
    super(Order);
  }
}
