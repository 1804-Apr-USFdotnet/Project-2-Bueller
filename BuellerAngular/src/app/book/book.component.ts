import { Component, OnInit , ViewChild} from '@angular/core';
import { NgModule } from '@angular/core';
import {debounceTime, distinctUntilChanged, map} from 'rxjs/operators';
import {NgbTypeahead} from '@ng-bootstrap/ng-bootstrap';
import { BookService } from "../book.service";
import { Book } from "../models/Book";

import {Observable, Subject} from 'rxjs';
import { DataSource } from "@angular/cdk/collections";
import { ShoppingCart } from "../Models/ShoppingCart";
import { ShoppingCartService } from "../services/shopping-cart.service";
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})

export class BookComponent implements OnInit {
  
  p: number = 1;
  books:  [    {BookTitle: ''}   ];
  constructor(private bookSvc: BookService, private shoppingCartService: ShoppingCartService) { }
  model: any;
  @ViewChild('instance') instance: NgbTypeahead;
 
 






  displayedColums = [
    'bookTitle', 'price'
  ]

  public  userFilter: any = { BookTitle: 'math' };
  


  ngOnInit() {
    this.bookSvc.getAllBooks( (response) => {
      this.books = response;
      console.log(response);
    });


  }




}



