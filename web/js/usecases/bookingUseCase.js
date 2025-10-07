import { apiClient } from "../infrastructure/apiClient.js";
import { Booking } from "../core/models/Booking.js";

export const bookingUseCase = {
    async getAll() {
        const res = await apiClient.get("/api/bookings");
        if (!res.ok) return [];
        const data = await res.json();
        return data.map(b => new Booking(b));
    },
    async delete(id) {
        return await apiClient.delete(`/api/bookings/${id}`);
    }
};
