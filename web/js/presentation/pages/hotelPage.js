import { apiClient } from "../../infrastructure/apiClient.js";

export function hotelPage() {
    return {
        hotel: {},
        rooms: [],
        async load() {
            const params = new URLSearchParams(location.search);
            const id = params.get("id");
            const hotelRes = await apiClient.get(`/api/hotels/${id}`);
            this.hotel = await hotelRes.json();

            const roomRes = await apiClient.get(`/api/rooms?hotelId=${id}`);
            this.rooms = await roomRes.json();
        },
        async book(roomId) {
            const token = localStorage.getItem("token");
            if (!token) {
                alert("Please login first");
                location.href = "/login.html";
                return;
            }
            const checkIn = prompt("Enter check-in date (YYYY-MM-DD):");
            const checkOut = prompt("Enter check-out date (YYYY-MM-DD):");
            const res = await apiClient.post("/api/bookings", {
                roomId, checkInDate: checkIn, checkOutDate: checkOut,
            });
            const text = await res.text();
            alert(text);
        },
    };
}
