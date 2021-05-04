import { Component, OnInit, ViewChild, ViewChildren, QueryList, ChangeDetectorRef } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTable } from '@angular/material/table';

import { ProductService } from '../../services/product.service';
import { Product, ProductArticle } from '../../../../core/models/Product';

@Component({
  selector: 'app-product-overview',
  templateUrl: './product-overview.component.html',
  styleUrls: ['./product-overview.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class ProductOverviewComponent implements OnInit {

  @ViewChild('outerSort', { static: true }) sort: MatSort = new MatSort();
  @ViewChildren('innerSort') innerSort: QueryList<MatSort> = new QueryList<MatSort>();
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<ProductArticle>> = new QueryList<MatTable<ProductArticle>>();

  dataSource : MatTableDataSource<Product> = new MatTableDataSource<Product> ();
  columnsToDisplay = ['id', 'name', 'description'];
  innerDisplayedColumns = ['id', 'name', 'amount', 'price'];
  expandedElement: Product | null = null;

  constructor(
    private productService: ProductService, private cd: ChangeDetectorRef) { }


  toggleRow(element: Product) {
    element.articles  ? (this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.cd.detectChanges();
    this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<ProductArticle>).sort = this.innerSort.toArray()[index]);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.productService.GetAllProducts()
      .subscribe(data => {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
      });
  }

}
