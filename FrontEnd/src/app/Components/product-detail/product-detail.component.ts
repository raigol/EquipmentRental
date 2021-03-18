import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Equipment } from 'src/app/Domain/Equipment';
import { ShoppingCart } from 'src/app/Domain/ShoppingCart';
import { CartService } from 'src/app/Services/cart.service';
import { EquipmentService } from 'src/app/Services/equipment.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  equipment: Equipment;
  public orderForm: FormGroup = new FormGroup({
    quantity: new FormControl('', [Validators.required, Validators.min(1), Validators.max(1000)])
  });

  constructor(private route: ActivatedRoute,
    private equipmentService: EquipmentService, 
    private cartService: CartService) { 
    
  }

  ngOnInit(): void {
    this.getEquipment();
  }

  getEquipment(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.equipmentService.getEquipmentById(id)
      .subscribe(equipment => this.equipment = equipment);
  }

  addToCart(): void {
    let shoppingCart = new ShoppingCart(this.equipment, this.orderForm.get('quantity').value);
    this.cartService.addToCart(shoppingCart);
    window.alert('Product has been added to the cart!');
  }

}
