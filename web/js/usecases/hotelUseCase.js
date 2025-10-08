import { apiClient } from "../infrastructure/apiClient.js";
import { Hotel } from "../core/models/Hotel.js";

export const hotelUseCase = {
    async getAll() {
        const res = await apiClient.get("/api/hotels");
        if (!res.ok) {
            console.error("API error:", res.status);
            return [];
        }
        const data = await res.json();
        return data.map(h => new Hotel(h));
    }
};
