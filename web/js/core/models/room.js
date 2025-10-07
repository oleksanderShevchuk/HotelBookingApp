export class Room {
    constructor({ id, number, capacity, pricePerNight, hotelId, hotelName, roomCategoryName }) {
        this.id = id;
        this.number = number;
        this.capacity = capacity;
        this.pricePerNight = pricePerNight;
        this.hotelId = hotelId;
        this.hotelName = hotelName;
        this.roomCategoryName = roomCategoryName;
    }
}
