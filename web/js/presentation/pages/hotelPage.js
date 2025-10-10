import { apiClient } from "../../infrastructure/apiClient.js";

/* helpers для дат */
function daysBetween(a, b) {
    const A = new Date(a), B = new Date(b);
    if (isNaN(+A) || isNaN(+B)) return 0;
    A.setHours(0, 0, 0, 0); B.setHours(0, 0, 0, 0);
    return Math.max(0, Math.round((B - A) / (1000 * 60 * 60 * 24)));
}
function yyyyMmDd(date = new Date()) {
    const d = new Date(date);
    d.setHours(0, 0, 0, 0);
    const m = String(d.getMonth() + 1).padStart(2, "0");
    const day = String(d.getDate()).padStart(2, "0");
    return `${d.getFullYear()}-${m}-${day}`;
}

export function hotelPage() {
    return {
        hotel: {},
        rooms: [],
        loading: false,
        error: "",

        // --- booking modal state ---
        booking: {
            open: false,
            room: null,
            checkIn: "",
            checkOut: "",
            saving: false
        },

        todayStr() { return yyyyMmDd(); },

        bookingSummary() {
            const { room, checkIn, checkOut } = this.booking;
            if (!room) return { nights: null, total: null, error: "Select a room" };
            if (!checkIn || !checkOut) return { nights: null, total: null, error: "Select both dates" };
            const nights = daysBetween(checkIn, checkOut);
            if (nights <= 0) return { nights: 0, total: 0, error: "Check-out must be after check-in" };
            const total = Number(room.pricePerNight || 0) * nights;
            return { nights, total, error: "" };
        },

        openBooking(room) {
            const token = localStorage.getItem("token");
            if (!token) {
                alert("Please login first");
                location.href = "/login.html";
                return;
            }
            this.booking.room = room;
            this.booking.checkIn = this.todayStr();
            const t = new Date();
            t.setDate(t.getDate() + 1);
            this.booking.checkOut = yyyyMmDd(t);
            this.booking.open = true;
            this.booking.saving = false;
        },

        closeBooking() {
            this.booking.open = false;
            this.booking.room = null;
            this.booking.checkIn = "";
            this.booking.checkOut = "";
            this.booking.saving = false;
        },

        async confirmBooking() {
            const { room, checkIn, checkOut } = this.booking;
            const token = localStorage.getItem("token");
            if (!token) {
                alert("Please login first");
                location.href = "/login.html";
                return;
            }
            const summary = this.bookingSummary();
            if (summary.error) return; // помилка вже показується у модалці

            try {
                this.booking.saving = true;
                const res = await apiClient.post("/api/bookings", {
                    roomId: room.id,
                    checkInDate: checkIn,
                    checkOutDate: checkOut
                });
                const text = await safeText(res);
                if (!res.ok) {
                    alert(text || "Booking failed");
                    this.booking.saving = false;
                    return;
                }
                alert(text || "Booked successfully!");
                this.closeBooking();
            } catch (e) {
                console.error(e);
                alert("Unexpected error");
            } finally {
                this.booking.saving = false;
            }
        },

        // --- твій load(), тільки з sessionStorage як джерелом id ---
        async load() {
            try {
                this.loading = true;
                this.error = "";

                const id = sessionStorage.getItem("selectedHotelId");
                if (!id) {
                    this.error = "Hotel id is missing.";
                    return;
                }

                const hRes = await apiClient.get(`/api/hotels/${encodeURIComponent(id)}`);
                if (!hRes.ok) {
                    const msg = await safeText(hRes);
                    this.error = `Failed to load hotel: ${hRes.status} ${msg || ""}`.trim();
                    return;
                }
                this.hotel = await hRes.json();

                const rRes = await apiClient.get(`/api/rooms?hotelId=${encodeURIComponent(id)}`);
                if (!rRes.ok) {
                    const msg = await safeText(rRes);
                    this.error = `Failed to load rooms: ${rRes.status} ${msg || ""}`.trim();
                    this.rooms = [];
                    return;
                }
                this.rooms = await rRes.json();

            } catch (e) {
                console.error(e);
                this.error = "Unexpected error. Try again later.";
            } finally {
                this.loading = false;
            }
        }
    };
}

async function safeText(res) {
    try { return await res.text(); } catch { return ""; }
}
