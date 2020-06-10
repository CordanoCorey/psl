import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsComponent } from './products.component';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product/product.component';
import { InventoryComponent } from './inventory/inventory.component';

@NgModule({
  declarations: [ProductsComponent, ProductComponent, InventoryComponent],
  imports: [
    SharedModule,
    ProductsRoutingModule
  ],
  exports: [
    InventoryComponent
  ]
})
export class ProductsModule { }
