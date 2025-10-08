export function adminNav() {
    return {
        isActive(path) {
            try {
                const current = location.pathname.replace(/\/+$/, '');
                const check = path.replace(/\/+$/, '');
                return current.endsWith(check);
            } catch {
                return false;
            }
        }
    };
}
