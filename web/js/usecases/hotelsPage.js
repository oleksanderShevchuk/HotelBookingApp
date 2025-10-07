import { hotelUseCase } from "../../usecases/hotelUseCase.js";

export function hotelsPage() {
    return {
        hotels: [],
        async init() {
            this.hotels = await hotelUseCase.getAll();
        }
    }
}
