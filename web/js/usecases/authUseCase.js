import { apiClient } from "../infrastructure/apiClient.js";
import { jwt } from "../core/utils/jwt.js";

export const authUseCase = {
    async login(email, password) {
        const res = await apiClient.post("/api/auth/login", { email, password });
        if (!res.ok) return { success: false, message: "Invalid credentials" };

        const data = await res.json();
        const token = data.token;

        const userData = jwt.decodeUser(token);
        localStorage.setItem("token", token);
        localStorage.setItem("user", JSON.stringify(userData));

        return { success: true, user: userData };
    },

    async register({ userName, email, password, role = "Client" }) {
        const res = await apiClient.post("/api/auth/register", { userName, email, password, role });
        const msg = await res.text();
        return { success: res.ok, message: msg };
    },

    logout() {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
    }
};
