import { adminBookingsPage } from "../../presentation/pages/adminBookingsPage.js";

function register() { Alpine.data("adminBookingsPage", adminBookingsPage); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
