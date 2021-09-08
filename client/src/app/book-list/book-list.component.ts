import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Book } from '../_models/book';
import { BooksService } from '../_services/books.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {  
  books : any;
  constructor(private booksService: BooksService) { }

  ngOnInit(): void {
    this.booksService.getBooks().subscribe(books => {
      this.books = books;
    }, error =>{
      console.log(error);
    });
  }

}
