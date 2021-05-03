import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';

import { Product } from '../../../core/models/Product';
import { ProductStock } from '../../../core/models/ProductStock';

@Injectable()
export class ProductService{
    constructor(private http: HttpClient) { }

    GetAllProducts() {
        return this.http.get<Product[]>(environment.apiEndpoint + "Products")
        .pipe(
            retry(3),
            catchError(this.handleError)
        );       
    }

    GetAllProductStocks() {
        return this.http.get<ProductStock[]>(environment.apiEndpoint + "products/stocks")
        .pipe(
            retry(3),
            catchError(this.handleError)
        );       
    }

    SellAProduct(id: number){
        return this.http.post<number>(environment.apiEndpoint + "Products/sell", id)
        .pipe(
            retry(3),
            catchError(this.handleError)
        )
    };

    UploadArticles(file: File) {
        const formData = new FormData();
        formData.append("file", file);
        return this.http.post(environment.apiEndpoint + "products/upload", formData)
        .pipe(
          retry(3),
          catchError(this.handleError)
        );
    }

    private handleError(error: HttpErrorResponse) {
        if (error.status === 0) {
          console.error('An error occurred:', error.error);
        } else {
          console.error(
            `Backend returned code ${error.status}, ` +
            `body was: ${error.error}`);
        }
        return throwError(
          'Something bad happened; please try again later.');
      }
}