import { apiClient } from "../infrastructure/apiClient.js";
import { Room } from "../core/models/Room.js";

export const roomUseCase = {
    async getAll(hotelId = null) {
        const res = await apiClient.get(`/api/rooms${hotelId ? `?hotelId=${hotelId}` : ""}`);
        if (!res.ok) return [];
        const data = await res.json();
        return data.map(r => new Room(r));
    },
    async create(room) {
        return await apiClient.post("/api/rooms", room);
    },
    async update(id, room) {
        return await apiClient.put(`/api/rooms/${id}`, room);
    },
    async delete(id) {
        return await apiClient.delete(`/api/rooms/${id}`);
    }
};
