export class User {
    constructor({ id, email, role }) {
        this.id = id;
        this.email = email;
        this.role = role;
    }

    static current() {
        const data = localStorage.getItem("user");
        return data ? new User(JSON.parse(data)) : null;
    }

    static logout() {
        localStorage.removeItem("user");
        localStorage.removeItem("token");
        location.href = "/login.html";
    }
}
