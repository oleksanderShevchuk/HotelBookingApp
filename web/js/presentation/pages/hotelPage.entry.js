import { hotelPage } from "../../presentation/pages/hotelPage.js";

function register() { Alpine.data("hotelPage", hotelPage); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
