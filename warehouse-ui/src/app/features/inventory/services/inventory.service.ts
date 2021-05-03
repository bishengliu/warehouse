import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';

import { Article } from '../../../core/models/Article';

@Injectable()
export class InventoryService{
    constructor(private http: HttpClient) { }

    GetAllArticles() {
        return this.http.get<Article[]>(environment.apiEndpoint + "inventory")
        .pipe(
            retry(3),
            catchError(this.handleError)
        );
        
    }


    UploadArticles(file: File) {
      const formData = new FormData();
      formData.append("file", file);
      return this.http.post(environment.apiEndpoint + "inventory/upload", formData)
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