export const apiClient = {
    baseUrl: "http://localhost:5232",

    async request(method, url, body = null) {
        const token = localStorage.getItem("token");
        const headers = {
            "Content-Type": "application/json",
        };
        if (token) headers["Authorization"] = `Bearer ${token}`;

        const res = await fetch(this.baseUrl + url, {
            method,
            headers,
            body: body ? JSON.stringify(body) : null,
        });

        if (res.status === 401) {
            console.warn("Unauthorized – clearing token");
            localStorage.removeItem("token");
            location.href = "/login.html";
        }

        return res;
    },

    get(url) { return this.request("GET", url); },
    post(url, body) { return this.request("POST", url, body); },
    put(url, body) { return this.request("PUT", url, body); },
    delete(url) { return this.request("DELETE", url); }
};
