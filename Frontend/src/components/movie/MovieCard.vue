<template>
  <v-col cols="12" sm="3">
    <v-card id="moviecard">
      <v-img class="pl-2" cover :src="movie.coverImage"></v-img>
      <v-card-title> {{ movie.name }} </v-card-title>
      <v-card-text>
        {{ moviePlot }}
      </v-card-text>
      <v-card-actions>
        <v-btn depressed class="white blue--text" @click="open"
          ><small class="text-capitalize">Explore--></small></v-btn
        >
        <v-spacer></v-spacer>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn
              icon
              class="blue--text"
              v-on="on"
              @click="editMovie(movie.id)"
            >
              <span class="material-symbols-outlined"> edit </span>
            </v-btn>
          </template>
          <span>EditMovie</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn icon v-on="on" @click="deleteMovie" class="red--text"
              ><span class="material-symbols-outlined"> delete </span></v-btn
            >
          </template>
          <span>DeleteMovie</span>
        </v-tooltip>
      </v-card-actions>
    </v-card>
  </v-col>
</template>
<script>
export default {
  props: ["movie"],
  emits: ["openmodal", "deletemovie"],

  computed: {
    moviePlot() {
      return this.movie.plot.substring(0, 150) + "...";
    },
  },

  methods: {
    open() {
      this.$emit("openmodal");
    },
    deleteMovie() {
      this.$emit("deletemovie");
    },
    editMovie(id) {
      this.$router.push({
        path: "/movies/" + id,
      });
    },
  },
};
</script>
<style scoped>
#moviecard {
  box-shadow: 0px 0px 2px 2px #cfcbcb;
  transition: box-shadow 0.3s;
}

#moviecard:hover {
  box-shadow: 0px 0px 3px 3px #3ed4fa;
}
</style>


