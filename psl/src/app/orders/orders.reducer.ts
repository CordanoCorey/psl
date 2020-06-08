import { Action } from '@caiu/library';

import { Orders } from './orders.model';

export class OrdersActions {
  static GET = '[Orders] GET';
}

export function ordersReducer(state: Orders = new Orders(), action: Action): Orders {
  switch (action.type) {

    default:
      return state;
  }
}
