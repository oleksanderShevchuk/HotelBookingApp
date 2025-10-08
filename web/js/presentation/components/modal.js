// /js/presentation/components/modal.js
export function modalComp() {
    return {
        open: false,
        title: "",
        data: {},
        original: null,        // ← для diff
        labels: {},            // ← { fieldKey: "Human Label" }
        lookups: {},           // ← { hotels: [...], rooms: [...] } для селектів
        mode: "edit",          // "edit" | "create"
        errors: {},
        saving: false,
        onSave: null,

        show(title, data, onSave, opts = {}) {
            const {
                original = null, labels = {}, mode = (data?.id ? "edit" : "create"),
                lookups = {}
            } = opts;
            this.title = title;
            this.data = { ...data };
            this.original = original ? { ...original } : null;
            this.labels = labels;
            this.mode = mode;
            this.lookups = lookups;
            this.errors = {};
            this.onSave = onSave;
            this.open = true;
        },

        validate(required = []) {
            const errs = {};
            for (const key of required) {
                const v = this.data[key];
                if (v === undefined || v === null || String(v).trim() === "") errs[key] = "Required";
            }
            this.errors = errs;
            return Object.keys(errs).length === 0;
        },

        pretty(key) {
            if (this.labels && this.labels[key]) return this.labels[key];
            return key.replace(/([A-Z])/g, " $1").replace(/_/g, " ").trim().replace(/^./, s => s.toUpperCase());
        },

        changes() {
            const out = [];
            if (!this.original) {
                for (const k of Object.keys(this.data)) {
                    const v = this.data[k];
                    if (v !== undefined && v !== null && `${v}`.trim() !== "") out.push({ key: k, label: this.pretty(k), oldVal: null, newVal: v });
                }
                return out;
            }
            const keys = Array.from(new Set([...Object.keys(this.original), ...Object.keys(this.data)]));
            for (const k of keys) {
                const a = this.original[k], b = this.data[k];
                const sa = typeof a === "object" ? JSON.stringify(a) : `${a ?? ""}`;
                const sb = typeof b === "object" ? JSON.stringify(b) : `${b ?? ""}`;
                if (sa !== sb) out.push({ key: k, label: this.pretty(k), oldVal: a, newVal: b });
            }
            return out;
        },

        async save({ required = [] } = {}) {
            if (!this.validate(required)) return;
            if (!this.onSave) { this.open = false; return; }
            try { this.saving = true; await this.onSave({ ...this.data }); this.open = false; }
            catch (e) { console.error(e); this.errors._common = "Save failed. Try again."; }
            finally { this.saving = false; }
        }
    };
}
