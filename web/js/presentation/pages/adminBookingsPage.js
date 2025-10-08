// /js/presentation/pages/adminBookingsPage.js
import { bookingUseCase } from "../../usecases/bookingUseCase.js";
import { hotelUseCase } from "../../usecases/hotelUseCase.js";
import { roomUseCase } from "../../usecases/roomUseCase.js";

export function adminBookingsPage() {
    const labels = {
        userEmail: "User email",
        hotelId: "Hotel",
        roomId: "Room",
        checkInDate: "Check-in date",
        checkOutDate: "Check-out date"
    };

    return {
        bookings: [],
        hotels: [],
        rooms: [],
        async init() {
            const [b, h, r] = await Promise.all([
                bookingUseCase.getAll(),
                hotelUseCase.getAll(),
                roomUseCase.getAll()
            ]);
            this.bookings = b;
            this.hotels = h;
            this.rooms = r;
        },

        openAdd() {
            window.dispatchEvent(new CustomEvent("modal:show", {
                detail: {
                    title: "Add Booking",
                    data: { userEmail: "", hotelId: "", roomId: "", checkInDate: "", checkOutDate: "" },
                    onSave: async (payload) => {
                        await bookingUseCase.create(payload);
                        await this.init();
                    },
                    labels,
                    mode: "create",
                    lookups: { hotels: this.hotels, rooms: this.rooms }
                }
            }));
        },

        async deleteBooking(id) {
            if (!confirm("Delete this booking?")) return;
            await bookingUseCase.delete(id);
            await this.init();
        }
    };
}
