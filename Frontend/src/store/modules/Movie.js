export default {
    namespaced: true,
    state() {
        return {
            movies: [],
            singleMovie: null,
        }
    },
    mutations: {

        getAll(state, payload) {
            state.movies = payload;

        },

        getById(state, payload) {
            state.singleMovie = payload;
        },

        add(state, MovieData) {
            state.movies.push(MovieData);
        },

        delete(state, id) {

            state.movies = state.movies.filter(movie => movie.id !== id);

        },

        update(state, updatedata) {
            state.movies = state.movies.filter(movie => movie.id !== updatedata.id);
            state.movies.push(updatedata);
        }
    },
    actions: {

        async getAll(context) {
            const response = await fetch("https://localhost:44391/movies");
            const responseData = await response.json();

            if (!response.ok) {
                const error = new Error(responseData.message || 'Failed to fetch Movies');
                throw error;
            }
            context.commit('getAll', responseData);
        },

        async getById(context, movieid) {
            const response = await fetch(`https://localhost:44391/movies/${movieid}`);
            const responseData = await response.json();

            if (!response.ok) {
                const error = new Error(responseData.message || 'Failed to fetch Movie');
                throw error;
            }
            context.commit('getById', responseData);

        },
        async delete(context, movieid) {
            const response = await fetch(`https://localhost:44391/movies/${movieid}`, {
                method: "DELETE",
            });


            if (!response.ok) {
                const responseData = await response.json();
                const error = new Error(responseData.message || 'Failed to fetch Movie');
                throw error;
            }
            context.commit('delete', movieid);
        },

        async add(context, movie) {
            const formData = new FormData();
            formData.append("file", movie.coverimage);

            const imageResponse = await fetch("https://localhost:44391/movies/upload", {
                method: "POST",
                body: formData,
            });

            if (!imageResponse.ok) {
                const responseData = await imageResponse.json();
                console.error("Error caused when uploading image", responseData);
                return;
            }

            const imageurl = await imageResponse.text();
            movie.coverimage = imageurl;

            const response = await fetch("https://localhost:44391/movies", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(movie),

            });

            if (!response.ok) {
                const responseData = await response.json();
                const error = new Error(responseData.message || 'Failed to Add Movie');
                throw error;
            }
            context.commit("add", movie);
        },

        async update(context, movie) {
            if (typeof (movie.coverimage) !== "string") {
                const formData = new FormData();
                formData.append("file", movie.coverimage);

                const imgresponse = await fetch("https://localhost:44391/movies/upload", {
                    method: "POST",
                    body: formData,
                }
                );

                if (!imgresponse.ok) {
                    const errorData = await imgresponse.json();
                    console.error("Image Upload Error:", errorData);
                    return;
                }

                const imageUrl = await imgresponse.text();

                movie.coverimage = imageUrl;

            }

            const response = await fetch(`https://localhost:44391/movies/${movie.id}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(movie),

            });
            if (!response.ok) {
                const responseData = await response.json();
                const error = new Error(responseData.message || 'Failed to Update Movie');
                throw error;
            }
            context.commit("update", movie);
        }
    },

    getters: {

        getAll(state) {
            return state.movies;

        },
        getById(state) {
            return state.singleMovie;
        }

    }
};