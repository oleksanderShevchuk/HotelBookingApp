import { apiClient } from "../infrastructure/apiClient.js";
import { Hotel } from "../core/models/Hotel.js";

export const hotelUseCase = {
    async getAll() {
        const res = await apiClient.get("/api/hotels");
        if (!res.ok) return [];
        const data = await res.json();
        return data.map(h => new Hotel(h));
    },
    async getById(id) {
        const res = await apiClient.get(`/api/hotels/${id}`);
        if (!res.ok) return null;
        const data = await res.json();
        return new Hotel(data);
    }
};
