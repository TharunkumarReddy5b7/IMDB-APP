export default {
    namespaced: true,
    state() {
        return {
            genres: [],
        }
    },

    mutations: {
        getAll(state, payload) {
            state.genres = payload;
        }

    },

    actions: {
        async getAll(context) {
            const response = await fetch("https://localhost:44391/genres");
            const responseData = await response.json();

            if (!response.ok) {
                const error = new Error(responseData.message || 'Failed to fetch genres');
                throw error;
            }
            context.commit('getAll', responseData);
        }
    },


    getters: {
        getAll(state) {
            return state.genres;

        }

    }
};