import { adminNav } from "../components/adminNav.js";
function register() { Alpine.data("adminNav", adminNav); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
