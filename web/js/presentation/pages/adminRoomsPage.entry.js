import { adminRoomsPage } from "../../presentation/pages/adminRoomsPage.js";
function register() { Alpine.data("adminRoomsPage", adminRoomsPage); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
