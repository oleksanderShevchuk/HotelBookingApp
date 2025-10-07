export const jwt = {
    parse(token) {
        try {
            const base64Url = token.split('.')[1];
            const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            return JSON.parse(atob(base64));
        } catch {
            return null;
        }
    },
    decodeUser(token) {
        const data = this.parse(token);
        if (!data) return null;
        return {
            id: data.sub,
            email: data.email,
            role: data["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
        };
    }
};
