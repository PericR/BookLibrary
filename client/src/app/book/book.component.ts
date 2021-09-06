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

  constructor(private booksService: BooksService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getBook();
  }

  getBook(){
    this.booksService.getBook(this.route.snapshot.paramMap.get('id')).subscribe(book => {
      this.book = book;
      console.log(this.book);
    }, error =>{
      console.log(error);
    });
  }

}
