import { hotelUseCase } from "../../usecases/hotelUseCase.js";

export function hotelsPage() {
    return {
        hotels: [],
        search: "",
        async init() {
            this.hotels = await hotelUseCase.getAll();
        },
        filteredHotels() {
            const q = (this.search || "").toLowerCase();
            return this.hotels.filter(h =>
                (h.name || "").toLowerCase().includes(q) ||
                (h.city || "").toLowerCase().includes(q)
            );
        },
        goToHotel(hotel) {
            if (!hotel?.id) return;
            sessionStorage.setItem("selectedHotelId", String(hotel.id));
            const id = encodeURIComponent(String(hotel.id));
            location.href = `/hotel.html?id=${id}`;
        }
    };
}
