export class OrderItem {
    equipmentId: number;
    quantity: number;
    
    constructor(equipmentId: number, quantity: number){
        this.equipmentId = equipmentId;
        this.quantity = quantity;
    }
}