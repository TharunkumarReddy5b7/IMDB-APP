export default {
    namespaced: true,
    state() {
        return {
            actors: [],
        }
    },
    mutations: {
        getAll(state, payload) {
            state.actors = payload;

        },

        add(state, ActorData) {
            state.actors.push(ActorData);
        }
    },
    actions: {
        async getAll(context) {
            const response = await fetch("https://localhost:44391/actors");
            const responseData = await response.json();

            if (!response.ok) {
                const error = new Error(responseData.message || 'Failed to fetch Actors');
                throw error;
            }
            context.commit('getAll', responseData);

        },
        async add(context, data) {
            const response = await fetch("https://localhost:44391/actors", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            });

            if (!response.ok) {
                const responseData = await response.json();
                const error = new Error(responseData.message || 'Failed to Add Actors');
                throw error;
            }
            context.commit("add", data);

        }
    },

    getters: {

        getAll(state) {
            return state.actors;

        }

    }
};