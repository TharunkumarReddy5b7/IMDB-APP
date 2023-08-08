<template>
  <v-app>
    <v-container fluid>
      <v-btn class="blue white--text" to="/addMovie">Add Movie</v-btn>
      <h1 class="blue--text text-center font-weight-bolder">
        <i>MovieList</i>
      </h1>

      <v-row>
        <base-dialog
          v-if="!!error"
          :show="!!error"
          :error="error"
          @closemodal="errorHandle"
        ></base-dialog>
        <center>
          <h3 v-if="isMoviesLoading" class="text-center">Loading...</h3>
        </center>

        <movie-card
          v-for="movie in getAllMovies"
          :key="movie.id"
          :movie="movie"
          @openmodal="openModal(movie.id)"
          @deletemovie="deleteMovie(movie.id)"
        ></movie-card>
      </v-row>

      <div>
        <explore-modal
          v-if="modalVisible"
          :show="modalVisible"
          :movie="getMovie"
          @closemodal="closeModal"
        ></explore-modal>
      </div>
    </v-container>
  </v-app>
</template>

<script>
import MovieCard from "../components/movie/MovieCard.vue";
import ExploreModal from "../components/movie/ExploreModal.vue";
export default {
  components: {
    MovieCard,
    ExploreModal,
  },
  data() {
    return {
      modalVisible: false,

      isMoviesLoading: false,
      error: null,
    };
  },
  computed: {
    getAllMovies() {
      return this.$store.getters["movies/getAll"];
    },
    getMovie() {
      return this.$store.getters["movies/getById"];
    },
  },

  methods: {
    async loadMovies() {
      this.isMoviesLoading = true;
      try {
        await this.$store.dispatch("movies/getAll");
      } catch (error) {
        this.error =
          error.message || "Something went wrong while fetching Movies!";
      }
      this.isMoviesLoading = false;
    },

    async openModal(fid) {
      try {
        await this.$store.dispatch("movies/getById", fid);
      } catch (error) {
        this.error =
          error.message || "Something went wrong while fetching Movie Details!";
      }

      this.modalVisible = true;
    },
    errorHandle() {
      this.error = null;
    },

    async deleteMovie(fid) {
      try {
        await this.$store.dispatch("movies/delete", fid);
      } catch (error) {
        this.error =
          error.message || "Something went wrong while Deleting Movie";
      }

      this.loadMovies();
    },

    closeModal() {
      this.modalVisible = false;
    },
  },

  created() {
    this.loadMovies();
  },
};
</script>


