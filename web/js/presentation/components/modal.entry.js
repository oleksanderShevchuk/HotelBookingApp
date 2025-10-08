import { modalComp } from "../../presentation/components/modal.js";

function register() { Alpine.data("modalComp", modalComp); }
if (window.Alpine) register(); else document.addEventListener("alpine:init", register);

window.addEventListener("modal:show", (e) => {
    const el = document.querySelector('[x-data^="modalComp"]');
    if (!el) return;
    const modal = Alpine.$data(el);
    if (!modal || typeof modal.show !== "function") return;
    const { title, data, onSave, ...opts } = e.detail || {};
    modal.show(title, data, onSave, opts);
});

