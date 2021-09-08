import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Book } from '../_models/book';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  baseUrl = environment.apiUrl;
  bookFromGoogle: any;

  constructor(private http: HttpClient) { }

  getBooks() {
    return this.http.get(this.baseUrl + 'book/books');
  }

  getBook(id: string): Observable<Book> {
    return this.http.get<Book>(this.baseUrl + 'book/book/' + id).pipe(
      map(response => response))
  }

  buyBook(bookId: number) {
    return this.http.post(this.baseUrl + 'invoice/new-invoice/' + bookId, {});
  }

  getBookInfoFromGoogleBooks(isbn: string) {
    return this.http.get('https://www.googleapis.com/books/v1/volumes?q=' + isbn);
  }
}
