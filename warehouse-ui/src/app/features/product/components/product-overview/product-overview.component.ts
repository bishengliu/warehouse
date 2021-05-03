import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';

import { ProductService } from '../../services/product.service';
import { Product } from '../../../../core/models/Product';
@Component({
  selector: 'app-product-overview',
  templateUrl: './product-overview.component.html',
  styleUrls: ['./product-overview.component.css']
})
export class ProductOverviewComponent implements OnInit {

  dataSource : MatTableDataSource<Product> = new MatTableDataSource();

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.GetAllProducts()
      .subscribe(data => {
        console.log(data);
        this.dataSource = new MatTableDataSource(data);
      });
  }

}
