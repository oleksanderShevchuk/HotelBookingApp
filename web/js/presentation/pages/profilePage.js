import { userBookingUseCase } from "../../usecases/userBookingUseCase.js";
import { User } from "../../core/models/user.js";

export function profilePage() {
    return {
        bookings: [],
        user: User.current(),
        async init() {
            if (!this.user) {
                alert("Please login first.");
                location.href = "/login.html";
                return;
            }
            this.bookings = await userBookingUseCase.getMyBookings();
        },
        async cancelBooking(id) {
            if (!confirm("Cancel this booking?")) return;
            await userBookingUseCase.cancelBooking(id);
            this.init();
        },
        logout() { User.logout(); location.href = "/"; },
    };
}
