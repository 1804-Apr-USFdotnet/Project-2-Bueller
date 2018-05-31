import { CartItem } from "./CartItem";

export class  ShoppingCart{
  public items: CartItem[] = new Array<CartItem>();
  public deliveryOptionId: string;
  public grossTotal: number = 0;
  public deliveryTotal: number = 0;
  public itemsTotal: number = 0;
}