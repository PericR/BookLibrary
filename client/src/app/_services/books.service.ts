import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  baseUrl = environment.apiUrl;
  
  constructor(private httpClient: HttpClient) { }

  getBooks() {
    return this.httpClient.get(this.baseUrl + 'book/books');
  }

  getBook(id: string){
    return this.httpClient.get(this.baseUrl + 'book/book/' + id);
  }
}
