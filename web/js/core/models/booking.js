export class Booking {
    constructor({ id, userEmail, hotelName, roomNumber, checkInDate, checkOutDate, totalPrice }) {
        this.id = id;
        this.userEmail = userEmail ?? null;
        this.hotelName = hotelName ?? null;
        this.roomNumber = roomNumber ?? null;
        this.checkInDate = new Date(checkInDate);
        this.checkOutDate = new Date(checkOutDate);
        this.totalPrice = totalPrice;
    }
}