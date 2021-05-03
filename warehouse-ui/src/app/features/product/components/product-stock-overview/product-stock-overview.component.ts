import { Component, OnInit} from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router, NavigationEnd, RouterEvent  } from '@angular/router';
import { filter } from 'rxjs/operators';

import { ProductService } from '../../services/product.service';
import { ProductStock } from '../../../../core/models/ProductStock';

@Component({
  selector: 'app-product-stock-overview',
  templateUrl: './product-stock-overview.component.html',
  styleUrls: ['./product-stock-overview.component.css']
})
export class ProductStockOverviewComponent implements OnInit {

  dataSource : MatTableDataSource<ProductStock> = new MatTableDataSource<ProductStock> ();
  // events: Events;
  displayedColumns = ['id', 'name', 'stock', 'price', 'action'];
  constructor(private productService: ProductService, private router: Router) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  sellProduct(element: ProductStock) {
    this.productService.SellAProduct(element.id)
    .subscribe(_ => {
      element.stock--;
      this.router.navigate([this.router.url]);
    })
  }

  fetechData() {
    this.productService.GetAllProductStocks()
      .subscribe(data => {
        this.dataSource = new MatTableDataSource(data);
    });
  }

  ngOnInit(): void {
    
    this.fetechData();

      this.router.events.pipe(
        filter(event => event instanceof NavigationEnd)
      ).subscribe(() => {
        this.fetechData();
      });
  }

}
