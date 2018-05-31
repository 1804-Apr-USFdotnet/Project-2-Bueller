import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { Observer } from "rxjs";
import { ShoppingCart } from "../Models/ShoppingCart";
import { CartItem } from "../Models/CartItem";
import { Book } from '../Models/Book';
// import { StorageService } from "../services/storage.service";

const CART_KEY = "cart";

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  // Declare Variables
  private storage: Storage;
  private books: Book[];



  // Inject constructor with services
  constructor() { 
    // this.storage = this.storageService.get();
  }

// functions
  public addItem(book: Book, quantity: number): void {
    const cart = this.retrieve();
    let item = cart.items.find((p) => p.productId === book.BookId);
    if (item === undefined) {
      item = new CartItem();
      item.productId = book.BookId;
      cart.items.push(item);
    }

    item.quantity += quantity;
    cart.items = cart.items.filter((cartItem) => cartItem.quantity > 0);
    if (cart.items.length === 0) {
      cart.deliveryOptionId = undefined;
    }

}
private calculateCart(cart: ShoppingCart): void {
  cart.itemsTotal = cart.items
                        .map((item) => item.quantity * this.books.find((p) => p.Price === item.productId).Price)
                        .reduce((previous, current) => previous + current, 0);
  // cart.deliveryTotal = cart.deliveryOptionId ?
  //                       this.deliveryOptions.find((x) => x.id === cart.deliveryOptionId).price :
  //                       0;
  cart.grossTotal = cart.itemsTotal + cart.deliveryTotal;
}
private retrieve(): ShoppingCart {
  const cart = new ShoppingCart();
  const storedCart = this.storage.getItem(CART_KEY);
  // if (storedCart) {
  //   cart.updateFrom(JSON.parse(storedCart));
  // }
  return cart;
}

// private save(cart: ShoppingCart): void {
//   this.storage.setItem(CART_KEY, JSON.stringify(cart));
// }

}
