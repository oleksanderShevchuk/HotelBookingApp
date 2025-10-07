export function modal() {
    return {
        open: false,
        title: "",
        data: {},
        onSave: null,

        show(title, data, callback) {
            this.title = title;
            this.data = { ...data };
            this.onSave = callback;
            this.open = true;
        },
        async save() {
            if (this.onSave) await this.onSave(this.data);
            this.open = false;
        }
    };
}
