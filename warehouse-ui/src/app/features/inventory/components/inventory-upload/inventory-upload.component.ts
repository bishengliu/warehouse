import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { InventoryService } from '../../services/inventory.service';

@Component({
  selector: 'app-inventory-upload',
  templateUrl: './inventory-upload.component.html',
  styleUrls: ['./inventory-upload.component.css']
})
export class InventoryUploadComponent implements OnInit {

  fileName: string = "";
  constructor(private inventoryService: InventoryService, private router: Router) { }

  onFileSelected(event: any) {
    const file : File = event.target.files[0];
    if (file) {

      this.fileName = file.name;

      this.inventoryService.UploadArticles(file)
      .subscribe(
        _ => this.router.navigate(['']));
  }
  }
  ngOnInit(): void {
  }

}
