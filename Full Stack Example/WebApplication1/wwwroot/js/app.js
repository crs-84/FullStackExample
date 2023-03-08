const app = Vue.createApp({

    data() {
        return {
            users: [],
            currentUser: {},
            action: null
        }
    },
    mounted() {
        this.getUsers();
    },
    methods: {

        getUsers() {
            api.getUsers().then(response => {
                this.users = response.data;
            });
        },

        updateUser(user) {
            this.currentUser = user;
            this.action = "Edit";
        },

        deleteUser(userId) {
            let response = confirm("Are you sure you want to delete the user");
            if (response) {
                api.deleteUser(userId).then(() => {
                    this.getUsers();
                });
            }
        },

        save() {
            if (this.action === "create") {
                api.createUser(this.currentUser).then(() => {
                    this.close();
                    this.getUsers();
                });
            }
            else {
                api.updateUser(this.currentUser).then(() => {
                    this.close();
                    this.getUsers();
                });
            }
        },

        close() {
            this.action = null;
            this.currentUser = {};
        }

    }


}).mount("#app");