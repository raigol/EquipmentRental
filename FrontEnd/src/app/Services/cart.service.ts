import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Invoice } from '../Domain/Invoice';
import { OrderItem } from '../Domain/OrderItem';
import { ShoppingCart } from '../Domain/ShoppingCart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpClient: HttpClient) { }

  items: ShoppingCart[] = [];


  addToCart(item: ShoppingCart) {
    this.items.push(item);
  }
  
  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }


  checkOutCart(orderItem: OrderItem[]): Observable<Invoice>{
    const headers = new HttpHeaders({
      'Content-Type':  'application/json'      
    });

    let url = `${environment.apiUrl}Order`;
    return this.httpClient.post<Invoice>(url, orderItem, {headers: headers});    
  }

}
