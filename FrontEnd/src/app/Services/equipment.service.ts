import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Equipment } from '../Domain/Equipment';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

  constructor(private httpClient: HttpClient) { }


  getEquipments(): Observable<Equipment[]> {
    return this.httpClient.get<Equipment[]>(`${environment.apiUrl}Equipment`)
  }

  getEquipmentById(equipmentId: number): Observable<Equipment> {
    return this.httpClient.get<Equipment>(`${environment.apiUrl}Equipment/${equipmentId}`)
  }

}
