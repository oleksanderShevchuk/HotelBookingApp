export function adminNav() {
    return {
        user: null,

        init() {
            this.user = JSON.parse(localStorage.getItem("user") || "null");

            window.addEventListener("storage", (e) => {
                if (e.key === "user" || e.key === "token") {
                    this.user = JSON.parse(localStorage.getItem("user") || "null");
                }
            });
        },

        isActive(path) {
            try {
                const current = location.pathname.replace(/\/+$/, "");
                const check = path.replace(/\/+$/, "");
                return current.endsWith(check);
            } catch {
                return false;
            }
        },

        isAdmin() {
            return this.user && this.user.role === "Admin";
        },

        requireAdmin(evt, path) {
            if (this.isAdmin()) {
                location.href = path;
                return;
            }
            evt?.preventDefault();
            alert("Access denied: admin only.");
        },

        guardAdmin() {
            if (!this.isAdmin()) {
                alert("You don't have access to this page.");
                location.replace("/index.html");
            }
        },

        goAdmin() {
            location.href = "/admin/hotels.html";
        },

        logout() {
            localStorage.removeItem("user");
            localStorage.removeItem("token");
            location.replace("/index.html");
        }
    };
}
