import { roomUseCase } from "../../usecases/roomUseCase.js";
import { hotelUseCase } from "../../usecases/hotelUseCase.js";

export function adminRoomsPage() {
    const labels = {
        number: "Room number",
        capacity: "Capacity",
        pricePerNight: "Price per night",
        hotelId: "Hotel"
    };

    return {
        rooms: [],
        hotels: [],
        filter: "",
        async init() {
            [this.rooms, this.hotels] = await Promise.all([
                roomUseCase.getAll(),
                hotelUseCase.getAll()
            ]);
        },
        filteredRooms() {
            const q = this.filter.trim().toLowerCase();
            if (!q) return this.rooms;
            return this.rooms.filter(r =>
                (r.hotelName || "").toLowerCase().includes(q) ||
                (String(r.number) || "").toLowerCase().includes(q)
            );
        },
        openAdd() {
            window.dispatchEvent(new CustomEvent("modal:show", {
                detail: {
                    title: "Add Room",
                    data: { number: "", capacity: 1, pricePerNight: 100, hotelId: "" },
                    onSave: async (payload) => { await roomUseCase.create(payload); await this.init(); },
                    labels,
                    mode: "create",
                    lookups: { hotels: this.hotels }
                }
            }));
        },
        openEdit(room) {
            window.dispatchEvent(new CustomEvent("modal:show", {
                detail: {
                    title: "Edit Room",
                    data: { ...room },
                    onSave: async (payload) => { await roomUseCase.update(room.id, payload); await this.init(); },
                    original: room,
                    labels,
                    mode: "edit",
                    lookups: { hotels: this.hotels }
                }
            }));
        },
        async deleteRoom(id) {
            if (!confirm("Delete this room?")) return;
            await roomUseCase.delete(id);
            await this.init();
        }
    };
}