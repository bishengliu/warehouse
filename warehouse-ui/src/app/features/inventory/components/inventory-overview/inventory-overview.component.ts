import { Component, OnInit } from '@angular/core';
import { InventoryService } from '../../services/inventory.service';

@Component({
  selector: 'app-inventory-overview',
  templateUrl: './inventory-overview.component.html',
  styleUrls: ['./inventory-overview.component.css']
})
export class InventoryOverviewComponent implements OnInit {

  constructor(private inventoryService: InventoryService) {
    
   }



  ngOnInit(): void {
    var result = this.inventoryService.GetAllArticles();
    result.subscribe(_ => console.log(_));
    
  }

}
