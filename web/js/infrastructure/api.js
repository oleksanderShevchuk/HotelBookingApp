const api = {
    baseUrl: "https://localhost:44379",

    async get(url) {
        return await fetch(this.baseUrl + url, {
            headers: this._headers(),
        });
    },

    async post(url, body) {
        return await fetch(this.baseUrl + url, {
            method: "POST",
            headers: this._headers(),
            body: JSON.stringify(body),
        });
    },

    async put(url, body) {
        return await fetch(this.baseUrl + url, {
            method: "PUT",
            headers: this._headers(),
            body: JSON.stringify(body),
        });
    },

    async delete(url) {
        return await fetch(this.baseUrl + url, {
            method: "DELETE",
            headers: this._headers(),
        });
    },

    _headers() {
        const token = localStorage.getItem("token");
        return {
            "Content-Type": "application/json",
            ...(token ? { Authorization: `Bearer ${token}` } : {}),
        };
    }
};
