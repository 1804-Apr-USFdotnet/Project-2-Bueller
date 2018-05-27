import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {

  constructor(private httpClient: HttpClient) { }

  getClasses( onSuccess) {
    var url = "https://localHost";
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );

  }
}
