import { apiClient } from "../infrastructure/apiClient.js";
import { Hotel } from "../core/models/Hotel.js";

async function safeText(res) {
    try { return await res.text(); } catch { return ""; }
}

async function safeJson(res) {
    if (res.status === 204) return null;

    const ct = res.headers.get("content-type") || "";
    if (!ct.toLowerCase().includes("application/json")) {
        const text = await safeText(res);
        return text || null;
    }

    const text = await safeText(res);
    if (!text) return null;
    try { return JSON.parse(text); } catch { return null; }
}

export const hotelUseCase = {
    async getAll() {
        const res = await apiClient.get("/api/hotels");
        if (!res.ok) {
            console.error("API error:", res.status);
            return [];
        }
        const data = await safeJson(res);
        const arr = Array.isArray(data) ? data : [];
        return arr.map(h => new Hotel(h));
    },

    async get(id) {
        const res = await apiClient.get(`/api/hotels/${encodeURIComponent(id)}`);
        if (!res.ok) throw new Error((await safeText(res)) || `HTTP ${res.status}`);
        const data = await safeJson(res);
        return data ? new Hotel(data) : null;
    },

    async create(payload) {
        const res = await apiClient.post("/api/hotels", payload);
        if (!res.ok) throw new Error((await safeText(res)) || `HTTP ${res.status}`);
        const data = await safeJson(res);
        return data && typeof data === "object" ? new Hotel(data) : true;
    },

    async update(id, payload) {
        const res = await apiClient.put(`/api/hotels/${encodeURIComponent(id)}`, payload);
        if (!res.ok) throw new Error((await safeText(res)) || `HTTP ${res.status}`);
        const data = await safeJson(res);
        return data && typeof data === "object" ? new Hotel(data) : true;
    },

    async delete(id) {
        const res = await apiClient.delete(`/api/hotels/${encodeURIComponent(id)}`);
        if (!res.ok && res.status == 500) alert('The hotel has related rooms or bookings.');
        if (!res.ok) throw new Error((await safeText(res)) || `HTTP ${res.status}`);
        return true;
    }
};