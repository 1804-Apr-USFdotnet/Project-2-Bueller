 import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private httpClient: HttpClient) { }

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
}
