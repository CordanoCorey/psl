import { Action } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Products } from './products.model';

export class ProductsActions {
  static GET = '[Products] GET';
}

export function productsReducer(state: Products = new Products(), action: Action): Products {
  switch (action.type) {

    case ProductsActions.GET:
      return state.update(action.payload);

    default:
      return state;
  }
}

export function productsSelector(store: Store<any>): Observable<Products> {
  return store.select('products');
}
