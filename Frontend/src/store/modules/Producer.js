export default {
    namespaced: true,
    state() {
        return {
            producers: [],
        }
    },
    mutations: {
        getAll(state, payload) {
            state.producers = payload;
        },
        add(state, payload) {
            state.producers.push(payload);
        }
    },
    actions: {
        async getAll(context) {
            const response = await fetch("https://localhost:44391/producers");
            const responseData = await response.json();
            if (!response.ok) {
                const error = new Error(responseData.message || 'Failed to fetch Producers');
                throw error;
            }

            context.commit('getAll', responseData)
        },
        async add(context, data) {
            const response = await fetch("https://localhost:44391/producers", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),

            });

            if (!response.ok) {
                const responseData = await response.json();
                const error = new Error(responseData.message || 'Failed to Add Producer');
                throw error;

            }
            context.commit("add", data);

        }
    },

    getters: {

        getAll(state) {
            return state.producers;

        }

    }
};