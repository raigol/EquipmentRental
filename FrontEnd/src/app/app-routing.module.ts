import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartComponent } from './Components/cart/cart.component';
import { InvoicesComponent } from './Components/invoices/invoices.component';
import { ProductDetailComponent } from './Components/product-detail/product-detail.component';
import { ProductsComponent } from './Components/products/products.component';

const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },
  { path: 'products', component: ProductsComponent },
  { path: 'invoices', component: InvoicesComponent },
  { path: 'products/:id', component: ProductDetailComponent },
  { path: 'cart', component: CartComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
