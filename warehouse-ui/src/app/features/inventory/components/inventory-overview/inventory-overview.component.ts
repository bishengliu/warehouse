import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';

import { InventoryService } from '../../services/inventory.service';

import { Article } from '../../../../core/models/Article';

@Component({
  selector: 'app-inventory-overview',
  templateUrl: './inventory-overview.component.html',
  styleUrls: ['./inventory-overview.component.css']
})
export class InventoryOverviewComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'price', 'stock', 'description', 'action'];
  dataSource : MatTableDataSource<Article> = new MatTableDataSource();

  constructor(private inventoryService: InventoryService) {}

   applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    var result = this.inventoryService.GetAllArticles();
    result.subscribe(articles => {
      // console.log(this.articles);
      this.dataSource = new MatTableDataSource(articles);
    });
    
  }

}
