import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Domain/Invoice';
import { InvoiceService } from 'src/app/Services/invoice.service';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  invoices: Invoice[] = [];
  loyaltyPoints: number = 0;

  constructor(private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.getInvoices();
    this.getLoyaltyPoints();
  }

  getInvoices(): void {
    this.invoiceService.getInvoices()
    .subscribe(invoices => this.invoices = invoices);
  }

  getLoyaltyPoints(): void {
    this.invoiceService.getLoyaltyPoints()
    .subscribe(loyaltyPoints => this.loyaltyPoints = loyaltyPoints);
  }

}
