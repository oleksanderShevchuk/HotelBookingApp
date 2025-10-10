// /js/usecases/roomUseCase.js
import { apiClient } from "../infrastructure/apiClient.js";
import { Room } from "../core/models/Room.js";

async function safeText(res) { try { return await res.text(); } catch { return ""; } }
async function safeJson(res) {
    if (res.status === 204) return null;
    const ct = (res.headers.get("content-type") || "").toLowerCase();
    const text = await safeText(res);
    if (!ct.includes("application/json") || !text) return null;
    try { return JSON.parse(text); } catch { return null; }
}

export const roomUseCase = {
    async getAll(hotelId = null) {
        const res = await apiClient.get(`/api/rooms${hotelId ? `?hotelId=${encodeURIComponent(hotelId)}` : ""}`);
        if (!res.ok) return [];
        const data = await safeJson(res) || [];
        return data.map(r => new Room(r));
    },

    async create(room) {
        const res = await apiClient.post("/api/rooms", room);
        if (!res.ok) throw new Error(await safeText(res) || `HTTP ${res.status}`);
        return (await safeJson(res)) || true;
    },

    async update(id, room) {
        const res = await apiClient.put(`/api/rooms/${encodeURIComponent(id)}`, room);
        if (!res.ok) throw new Error(await safeText(res) || `HTTP ${res.status}`);
        return (await safeJson(res)) || true;
    },

    async delete(id) {
        const res = await apiClient.delete(`/api/rooms/${encodeURIComponent(id)}`);
        if (!res.ok && res.status == 500) alert('The hotel has related bookings.');
        if (!res.ok) throw new Error(await safeText(res) || `HTTP ${res.status}`);
        return true;
    },

    async getAllRoomCategories() {
        const res = await apiClient.get("/api/rooms/categories");
        if (!res.ok) {
            console.error("GET /api/rooms/categories failed:", res.status, await safeText(res));
            return [];
        }
        const data = await safeJson(res) || [];
        return data.map(c => ({
            id: c.id,
            name: c.name,
            description: c.description ?? ""
        }));
    },
};
