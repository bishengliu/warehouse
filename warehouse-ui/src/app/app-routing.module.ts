import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { InventoryOverviewComponent } from './features/inventory/components/inventory-overview/inventory-overview.component';
import { InventoryUploadComponent } from './features/inventory/components/inventory-upload/inventory-upload.component';
import { ProductOverviewComponent } from './features/product/components/product-overview/product-overview.component';
import { ProductUploadComponent } from './features/product/components/product-upload/product-upload.component';
import { ProductStockOverviewComponent } from './features/product/components/product-stock-overview/product-stock-overview.component';


const routes: Routes = [
  {path: '', component: InventoryOverviewComponent},
  {path: 'inventory', component: InventoryOverviewComponent},
  {path: 'inventory/upload', component: InventoryUploadComponent},
  {path: 'products', component: ProductOverviewComponent},
  {path: 'products/upload', component: ProductUploadComponent},
  {path: 'products/stock', component: ProductStockOverviewComponent },
  { path: '**', redirectTo: '/inventory', pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    onSameUrlNavigation: 'reload'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
