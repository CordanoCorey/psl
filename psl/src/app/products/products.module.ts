import { NgModule } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsComponent } from './products.component';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product/product.component';
import { InventoryComponent } from './inventory/inventory.component';
import { ProductCategoriesComponent } from './product-categories/product-categories.component';

@NgModule({
  declarations: [ProductsComponent, ProductComponent, InventoryComponent, ProductCategoriesComponent],
  imports: [
    SharedModule,
    ProductsRoutingModule,
    MatGridListModule
  ],
  exports: [
    InventoryComponent
  ]
})
export class ProductsModule { }
