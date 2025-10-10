import { roomUseCase } from "../../usecases/roomUseCase.js";
import { hotelUseCase } from "../../usecases/hotelUseCase.js";

export function adminRoomsPage() {
    const labels = {
        number: "Room number",
        capacity: "Capacity",
        pricePerNight: "Price per night",
        hotelId: "Hotel",
        roomCategoryId: "Category"
    };

    return {
        rooms: [],
        hotels: [],
        categories: [],
        filter: "",

        async init() {
            const [rooms, hotels, categories] = await Promise.all([
                roomUseCase.getAll(),
                hotelUseCase.getAll(),
                roomUseCase.getAllRoomCategories() 
            ]);
            this.rooms = rooms;
            this.hotels = hotels;
            this.categories = categories;
        },

        filteredRooms() {
            const q = this.filter.trim().toLowerCase();
            if (!q) return this.rooms;
            return this.rooms.filter(r =>
                (r.hotelName || "").toLowerCase().includes(q) ||
                (String(r.number) || "").toLowerCase().includes(q) ||
                (r.roomCategoryName || "").toLowerCase().includes(q)
            );
        },

        openAdd() {
            window.dispatchEvent(new CustomEvent("modal:show", {
                detail: {
                    title: "Add Room",
                    data: { number: "", capacity: 1, pricePerNight: 100, hotelId: "", roomCategoryId: "" },
                    onSave: async (payload) => { await roomUseCase.create(payload); await this.init(); },
                    labels,
                    mode: "create",
                    lookups: { hotels: this.hotels, categories: this.categories }
                }
            }));
        },

        openEdit(room) {
            window.dispatchEvent(new CustomEvent("modal:show", {
                detail: {
                    title: "Edit Room",
                    data: {
                        id: room.id,
                        number: room.number,
                        capacity: room.capacity,
                        pricePerNight: room.pricePerNight,
                        hotelId: room.hotelId,
                        roomCategoryId: room.roomCategoryId
                    },
                    onSave: async (payload) => { await roomUseCase.update(room.id, payload); await this.init(); },
                    original: room,
                    labels,
                    mode: "edit",
                    lookups: { hotels: this.hotels, categories: this.categories }
                }
            }));
        },

        async deleteRoom(id) {
            if (!confirm("Delete this room?")) return;
            try {
                await roomUseCase.delete(id);
                await this.init();
            } catch (e) {
                alert(e?.message || "Delete failed.");
            }
        }
    };
}
