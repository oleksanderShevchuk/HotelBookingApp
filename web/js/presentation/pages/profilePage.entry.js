import { profilePage } from "../../presentation/pages/profilePage.js";

function register() { Alpine.data("profilePage", profilePage); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);
