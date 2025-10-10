import { apiClient } from "../infrastructure/apiClient.js";
import { Booking } from "../core/models/booking.js";

export const userBookingUseCase = {
    async getMyBookings() {
        const res = await apiClient.get("/api/bookings/my");
        if (!res.ok) return [];
        const data = await res.json();
        return data.map(b => new Booking(b));
    },
    async cancelBooking(id) {
        return await apiClient.delete(`/api/bookings/${id}`);
    }
};
