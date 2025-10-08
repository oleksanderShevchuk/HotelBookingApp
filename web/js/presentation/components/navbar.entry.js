import { navbar } from "../components/navbar.js";
function register() { Alpine.data("navbar", navbar); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
