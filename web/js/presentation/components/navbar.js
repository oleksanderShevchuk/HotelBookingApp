import { User } from "/js/core/models/User.js";

export function navbar() {
    return {
        user: User.current(),
        isAdmin() { return this.user && this.user.role === "Admin"; },
        logout() { User.logout(); location.href = "/"; }
    };
}
