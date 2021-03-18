import { Equipment } from "./Equipment";

export class ShoppingCart {
    equipment: Equipment;
    days: number;
    
    constructor(equipment: Equipment, days: number){
        this.equipment = equipment;
        this.days = days;
    }
}