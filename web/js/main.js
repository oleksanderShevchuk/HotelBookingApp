import { hotelsPage } from "./presentation/pages/hotelsPage.js";

document.addEventListener("alpine:init", () => {
    Alpine.data("hotelsPage", hotelsPage);
});
