import { authUseCase } from "../../usecases/authUseCase.js";

function registerPage() {
    return {
        userName: "",
        email: "",
        password: "",
        message: "",
        async register() {
            const { success, message } = await authUseCase.register({
                userName: this.userName,
                email: this.email,
                password: this.password,
                role: "Client",
            });
            this.message = message || "";
            if (success) {
                alert("Registration successful!");
                location.href = "login.html";
            }
        },
    };
}

function registerAlpineComponent() {
    Alpine.data("registerPage", registerPage);
}

if (window.Alpine) {
    registerAlpineComponent();
} else {
    document.addEventListener("alpine:init", registerAlpineComponent);
}
