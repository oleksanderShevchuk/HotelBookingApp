import { hotelUseCase } from "../../../usecases/hotelUseCase.js";
import { modal } from "../components/modal.js";

export function adminHotelsPage() {
    return {
        hotels: [],
        modal: modal(),

        async init() {
            this.hotels = await hotelUseCase.getAll();
        },

        openAdd() {
            this.modal.show("Add Hotel", { name: "", city: "", address: "", description: "" }, async (data) => {
                await hotelUseCase.create(data);
                this.init();
            });
        },

        openEdit(hotel) {
            this.modal.show("Edit Hotel", { ...hotel }, async (data) => {
                await hotelUseCase.update(hotel.id, data);
                this.init();
            });
        },

        async deleteHotel(id) {
            if (confirm("Delete this hotel?")) {
                await hotelUseCase.delete(id);
                this.init();
            }
        }
    };
}
