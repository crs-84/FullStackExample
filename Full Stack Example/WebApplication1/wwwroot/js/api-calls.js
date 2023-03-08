const api = {

    getUsers() {
        let url = "/api/users";
        return axios.get(url);
    },

    createUser(user) {
        let url = "/api/users";
        return axios.post(url, user);
    },

    updateUser(user) {
        let url = "/api/users";
        return axios.put(url, user);
    },

    deleteUser(userId) {
        let url = `/api/users/${userId}`;
        return axios.delete(url);
    }

};