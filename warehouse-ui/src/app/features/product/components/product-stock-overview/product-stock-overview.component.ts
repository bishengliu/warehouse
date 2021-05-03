import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, MatTable } from '@angular/material/table';

import { ProductService } from '../../services/product.service';
import { ProductStock } from '../../../../core/models/ProductStock';

@Component({
  selector: 'app-product-stock-overview',
  templateUrl: './product-stock-overview.component.html',
  styleUrls: ['./product-stock-overview.component.css']
})
export class ProductStockOverviewComponent implements OnInit {

  dataSource : MatTableDataSource<ProductStock> = new MatTableDataSource<ProductStock> ();
  displayedColumns = ['id', 'name', 'stock', 'price'];

  constructor(private productService: ProductService) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.productService.GetAllProductStocks()
      .subscribe(data => {
        this.dataSource = new MatTableDataSource(data);
      });
  }

}
