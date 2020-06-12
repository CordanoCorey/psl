import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductsComponent } from './products.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  {
    path: ':productId',
    component: ProductComponent,
    data: { routeName: 'product', routeLabel: 'Product' }
  },
  {
    path: '',
    component: ProductsComponent,
    data: { routeName: 'products', routeLabel: 'Products' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
