 import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Book } from './Models/Book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private httpClient: HttpClient) { }
private serviceUrl = "http://localhost:57265/api/book/getAll";







  getAllBooks(

    onSuccess,
    onFail = (reason) => console.log(reason)) {
   
      var url = "http://13.59.126.130/BuellerWebApi_deploy/api/book/getAll";
   
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      onFail
    );
  }
  getBooks(): Observable<Book[]>{
    return this.httpClient.get<Book[]>(this.serviceUrl)
     }
}
