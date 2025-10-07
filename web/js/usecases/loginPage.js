import { authUseCase } from "../../usecases/authUseCase.js";

export function loginPage() {
    return {
        email: "",
        password: "",
        message: "",
        async submit() {
            const { success, message, user } = await authUseCase.login(this.email, this.password);
            if (!success) {
                this.message = message;
                return;
            }
            location.href = user.role === "Admin" ? "/admin/hotels.html" : "/index.html";
        }
    }
}
