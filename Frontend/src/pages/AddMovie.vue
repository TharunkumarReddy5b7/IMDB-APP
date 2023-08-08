<template>
  <v-app>
    <base-dialog
      v-if="!!error"
      :show="!!error"
      :error="error"
      @closemodal="errorHandle"
    ></base-dialog>
    <h3
      class="text-center"
      v-else-if="
        isActorsLoading ||
        isGenresLoading ||
        isProducersLoading ||
        isMovieLoading
      "
    >
      Loading...
    </h3>

    <movie-form
      v-else
      :fid="routeid"
      :getActors="getActors"
      :getProducers="getProducers"
      :getGenres="getGenres"
      :selectedmovie="getMovie"
      @registermovie="registerOrUpdateMovie"
    ></movie-form>
  </v-app>
</template>
<script>
import MovieForm from "../components/movie/MovieForm.vue";
import Swal from "sweetalert2";
export default {
  data() {
    return {
      isActorsLoading: false,
      isProducersLoading: false,
      isGenresLoading: false,
      isMovieLoading: false,

      error: null,
      routeid: null,
    };
  },

  components: {
    MovieForm,
  },
  computed: {
    getActors() {
      return this.$store.getters["actors/getAll"];
    },
    getGenres() {
      return this.$store.getters["genres/getAll"];
    },
    getProducers() {
      return this.$store.getters["producers/getAll"];
    },
    getMovie() {
      return this.$store.getters["movies/getById"];
    },
  },

  methods: {
    async loadActors() {
      this.isActorsLoading = true;
      try {
        await this.$store.dispatch("actors/getAll");
      } catch (error) {
        this.error =
          error.message || "Something went wrong while fetching actors!";
      }
      this.isActorsLoading = false;
    },

    async registerOrUpdateMovie(movie) {
      if (this.routeid === null) {
        try {
          await this.$store.dispatch("movies/add", movie);
          Swal.fire({
            title: "success",
            text: "Movie Added Successfully",
            icon: "success",
            confirmButtonText: "Ok",
          }).then((result) => {
            if (result.isConfirmed) {
              this.$router.push("/movies");
            }
          });
        } catch (error) {
          this.error =
            error.message || "Something went wrong while Adding movie!";
        }
      } else {
        movie.id = this.routeid;
        try {
          await this.$store.dispatch("movies/update", movie);
          Swal.fire({
            title: "success",
            text: "Movie Updated Successfully",
            icon: "success",
            confirmButtonText: "Ok",
          }).then((result) => {
            if (result.isConfirmed) {
              this.$router.push("/movies");
            }
          });
        } catch (error) {
          this.error =
            error.message || "Something went wrong while Updating movie!";
        }
      }
    },

    async loadGenres() {
      this.isGenresLoading = true;
      try {
        await this.$store.dispatch("genres/getAll");
      } catch (error) {
        this.error =
          error.message || "Something went wrong while fetching genres!";
      }
      this.isGenresLoading = false;
    },

    async loadMovie() {
      this.isMovieLoading = true;
      try {
        await this.$store.dispatch("movies/getById", this.routeid);
      } catch (error) {
        this.error =
          error.message || "Something went wrong while fetching Movie Details!";
      }
      this.isMovieLoading = false;
    },

    async loadProducers() {
      this.isProducersLoading = true;
      try {
        await this.$store.dispatch("producers/getAll");
      } catch (error) {
        this.error =
          error.message || "Something went wrong while fetching producers!";
      }
      this.isProducersLoading = false;
    },

    errorHandle() {
      this.error = null;
    },
  },

  created() {
    const getId = this.$route.params.id;
    if (typeof getId !== "undefined") {
      this.routeid = getId;
      this.loadMovie();
    } else {
      this.routeid = null;
    }
    this.loadActors();
    this.loadGenres();
    this.loadProducers();
  },
};
</script>


<style scoped>
.containclass {
  background-color: rgb(193, 221, 221);
}
</style>