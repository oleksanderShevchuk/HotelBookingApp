import { authUseCase } from "../../usecases/authUseCase.js";

export function loginForm() {
    return {
        email: "",
        password: "",
        message: "",
        async submit() {
            try {
                const { success, message, user } = await authUseCase.login(this.email, this.password);
                if (!success) {
                    this.message = message || "Invalid credentials";
                    return;
                }
                location.href = user?.role === "Admin" ? "/admin/hotels.html" : "/index.html";
            } catch (e) {
                console.error(e);
                this.message = "Login failed. Try again.";
            }
        },
    };
}

function register() {
    Alpine.data("loginForm", loginForm);
}

if (window.Alpine) {
    register();
} else {
    document.addEventListener("alpine:init", register);
}
