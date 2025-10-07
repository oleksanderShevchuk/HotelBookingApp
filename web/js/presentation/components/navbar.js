import { User } from "../../core/models/User.js";

export function navbar() {
    return {
        user: User.current(),
        logout() {
            User.logout();
        }
    };
}
