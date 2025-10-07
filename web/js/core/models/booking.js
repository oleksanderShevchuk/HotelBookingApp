export class Booking {
    constructor({ id, roomId, userId, checkInDate, checkOutDate, totalPrice }) {
        this.id = id;
        this.roomId = roomId;
        this.userId = userId;
        this.checkInDate = new Date(checkInDate);
        this.checkOutDate = new Date(checkOutDate);
        this.totalPrice = totalPrice;
    }
}
