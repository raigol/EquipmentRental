import { Component, OnInit } from '@angular/core';
import { Equipment } from 'src/app/Domain/Equipment';
import { EquipmentService } from 'src/app/Services/equipment.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  equipment: Equipment[] = [];

  constructor(private equipmentService: EquipmentService) { }

  ngOnInit(): void {
    this.getEquipment();
  }
  

  getEquipment(): void {
    this.equipmentService.getEquipments()
    .subscribe(equipment => this.equipment = equipment);
  }

}
