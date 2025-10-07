import { bookingUseCase } from "../../../usecases/bookingUseCase.js";

export function adminBookingsPage() {
    return {
        bookings: [],
        async init() {
            this.bookings = await bookingUseCase.getAll();
        },
        async deleteBooking(id) {
            if (confirm("Delete this booking?")) {
                await bookingUseCase.delete(id);
                this.init();
            }
        }
    };
}
