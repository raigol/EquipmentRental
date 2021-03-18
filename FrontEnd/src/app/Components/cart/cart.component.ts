import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Domain/Invoice';
import { OrderItem } from 'src/app/Domain/OrderItem';
import { ShoppingCart } from 'src/app/Domain/ShoppingCart';
import { CartService } from 'src/app/Services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private cartService: CartService) { }
  items: ShoppingCart[] = [];
  orderItems: OrderItem[] = [];
  invoice: Invoice;

  ngOnInit(): void {
    this.items = this.cartService.getItems();
  }

  checkout(): void {
    
    for(let i = 0; i<this.items.length; i++){
      this.orderItems.push(new OrderItem(this.items[i].equipment.equipmentId, this.items[i].days))
    }

    this.cartService.checkOutCart(this.orderItems).subscribe(invoice => this.invoice = invoice);
    
    this.cartService.clearCart();
    this.items = [];
  }

}
