import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BooksService } from '../_services/books.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  book: any;
  bookFromGoogle: any;
  description: string;
  rating: string;

  constructor(private booksService: BooksService, private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.getBook();
  }

  getBook(){
    this.booksService.getBook(this.route.snapshot.paramMap.get('id')).subscribe(book => {
      this.book = book;
      console.log(this.book);
      this.getBookInfoFromGoogleBooks(book['isbn']);
    }, error =>{
      console.log(error);
    });
  }

  getBookInfoFromGoogleBooks(isbn: string) {
    this.http.get('https://www.googleapis.com/books/v1/volumes?q=' + isbn).subscribe(response => {
      this.bookFromGoogle = response;
      this.rating = this.bookFromGoogle['items'][0]['volumeInfo']['averageRating'];
      this.description = this.bookFromGoogle['items'][0]['volumeInfo']['description'];
    }, error => {
      console.log(error);
    })
  }

}
