import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Invoice } from '../Domain/Invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private httpClient: HttpClient) { }


  getInvoices(): Observable<Invoice[]> {
    let customerId = 1;
    return this.httpClient.get<Invoice[]>(`${environment.apiUrl}invoice/${customerId}`)
  }

  getLoyaltyPoints(): Observable<number> {
    let customerId = 1;
    return this.httpClient.get<number>(`${environment.apiUrl}invoice/LoyaltyPoints/${customerId}`)
  }
}
