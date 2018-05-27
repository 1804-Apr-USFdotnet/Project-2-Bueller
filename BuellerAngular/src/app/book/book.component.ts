import { Component, OnInit } from '@angular/core';
import { BookService } from "../book.service";
import { Book } from "../models/Book";
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

 books: Book[] = [
    {Title: "", price: 70.00,  classId: 1}
  ];
  constructor(private bookSvc: BookService) { }

  ngOnInit() {
  }
  getBooks(){
this.bookSvc.getAllBooks( (response) => {
      this.books = response.results;
    });

  }

}
