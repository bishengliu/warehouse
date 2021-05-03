import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-upload',
  templateUrl: './product-upload.component.html',
  styleUrls: ['./product-upload.component.css']
})
export class ProductUploadComponent implements OnInit {

  fileName: string = "";
  constructor(private productService: ProductService, private router: Router) { }

  onFileSelected(event: any) {
    const file : File = event.target.files[0];
    if (file) {

      this.fileName = file.name;

      this.productService.UploadArticles(file)
      .subscribe(
        _ => this.router.navigate(['/products']));
    }
  }

  ngOnInit(): void {
  }

}
