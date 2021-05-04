import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppMaterialModule } from './app-material.module';
import { InventoryOverviewComponent } from './features/inventory/components/inventory-overview/inventory-overview.component';
import { InventoryUploadComponent } from './features/inventory/components/inventory-upload/inventory-upload.component';
import { ProductOverviewComponent } from './features/product/components/product-overview/product-overview.component';
import { ProductUploadComponent } from './features/product/components/product-upload/product-upload.component';
import { ProductStockOverviewComponent } from './features/product/components/product-stock-overview/product-stock-overview.component';

import { InventoryService } from './features/inventory/services/inventory.service';
import { ProductService } from './features/product/services/product.service';
@NgModule({
  declarations: [
    AppComponent,
    InventoryOverviewComponent,
    InventoryUploadComponent,
    ProductOverviewComponent,
    ProductUploadComponent,
    ProductStockOverviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppMaterialModule
  ],
  providers: [
    InventoryService,
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
