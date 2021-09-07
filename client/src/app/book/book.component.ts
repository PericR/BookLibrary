import { HttpClient } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../_models/book';
import { BooksService } from '../_services/books.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  book: Book;
  bookInfoFromGoogle: any;
  description: string;
  rating: string;

  constructor(private booksService: BooksService, private route: ActivatedRoute, private http: HttpClient) { }
  

  ngOnInit(): void {
    this.getBook();
  }

  getBook(){
    this.booksService.getBook(this.route.snapshot.paramMap.get('id')).subscribe(book => {
      this.book = book;
      this.booksService.getBookInfoFromGoogleBooks(book.isbn).subscribe(response => {
        this.rating = response['items'][0]['volumeInfo']['averageRating'];
        this.description = response['items'][0]['volumeInfo']['description'];
      })
    });
  }

  buyBook(){
    this.booksService.buyBook(this.book.id).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

}
