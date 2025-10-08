import { hotelUseCase } from "../../usecases/hotelUseCase.js";

export function hotelsPage() {
    return {
        hotels: [],
        search: "",
        async init() {
            try {
                const data = await hotelUseCase.getAll();
                this.hotels = data;
            } catch (e) {
                console.error("Failed to load hotels", e);
            }
        },
        filteredHotels() {
            return this.hotels.filter(h =>
                h.name.toLowerCase().includes(this.search.toLowerCase()) ||
                h.city.toLowerCase().includes(this.search.toLowerCase())
            );
        }
    };
}
