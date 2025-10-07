import { roomUseCase } from "../../../usecases/roomUseCase.js";
import { modal } from "../components/modal.js";

export function adminRoomsPage() {
    return {
        rooms: [],
        modal: modal(),
        async init() {
            this.rooms = await roomUseCase.getAll();
        },
        openAdd() {
            this.modal.show("Add Room", { number: "", capacity: 1, pricePerNight: 100, hotelId: "" }, async (data) => {
                await roomUseCase.create(data);
                this.init();
            });
        },
        openEdit(room) {
            this.modal.show("Edit Room", { ...room }, async (data) => {
                await roomUseCase.update(room.id, data);
                this.init();
            });
        },
        async deleteRoom(id) {
            if (confirm("Delete this room?")) {
                await roomUseCase.delete(id);
                this.init();
            }
        }
    };
}
