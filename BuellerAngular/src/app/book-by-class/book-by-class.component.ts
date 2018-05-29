import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from "../models/Book";
import { BookService } from '../book.service';
@Component({
  selector: 'app-book-by-class',
  templateUrl: './book-by-class.component.html',
  styleUrls: ['./book-by-class.component.css']
})
export class BookByClassComponent implements OnInit {

  books:  [
    {}  
    ];
  constructor(

    private route: ActivatedRoute,    // needed to check route parameter
    private BookSvc: BookService

  ) { }

  ngOnInit() {

    var classId = this.route.snapshot.paramMap.get("classId"); // get "classId" parameter value
    this.BookSvc.getBooksByClassId(classId, (response) => {
      this.books = response;
    });
  }

}
