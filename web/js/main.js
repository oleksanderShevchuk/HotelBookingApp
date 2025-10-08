import { hotelsPage } from "./presentation/pages/hotelsPage.js";

document.addEventListener("alpine:init", () => {
    console.log("✅ Alpine init triggered — hotelsPage registered");
    Alpine.data("hotelsPage", hotelsPage);
});
