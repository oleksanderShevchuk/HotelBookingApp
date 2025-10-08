import { adminHotelsPage } from "../../presentation/pages/adminHotelsPage.js";
function register() { Alpine.data("adminHotelsPage", adminHotelsPage); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
