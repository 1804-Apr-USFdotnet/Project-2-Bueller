import { Component, OnInit } from '@angular/core';
import { NgModule } from '@angular/core';
import { BookService } from "../book.service";
import { Book } from "../models/Book";
import { observable, Observable } from "rxjs";
import { DataSource } from "@angular/cdk/collections";
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  dataSource = new bookDataSource(this.bookSvc);
  displayedColums = [
    'bookTitle', 'price'
  ]
  p: number = 1;
 books:  [
  {BookTitle: ''}  
  ];
  public  userFilter: any = { BookTitle: 'math' };
  
  constructor(private bookSvc: BookService) { }

  ngOnInit() {
    this.bookSvc.getAllBooks( (response) => {
      this.books = response;
      console.log(response);
    });


  }
  searchBooks(){

  }



}
export class bookDataSource extends DataSource<any>{

  constructor(private bookSvc: BookService){
    super()
  }
  connect(): Observable<Book[]>{
     console.warn(this.bookSvc.getBooks());
    return this.bookSvc.getBooks()
    
  
  }
  disconnect(){}
}

