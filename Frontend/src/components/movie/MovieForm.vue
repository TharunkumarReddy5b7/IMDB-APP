<template>
  <v-app>
    <v-row justify="center">
      <v-col cols="12" sm="10" lg="8">
        <v-container class="containclass">
          <h2 class="bg-red text-success text-center">
            {{ headTitle }} Movie Details
          </h2>

          <v-form
            class="font-weight-bold pl-9 pr-9"
            ref="movieform"
            @submit.prevent="submitMovieData"
          >
            <v-text-field
              label="Enter movie name"
              v-model="movieName"
              :rules="nameValidate"
            ></v-text-field>
            <v-text-field
              label="Year of Release"
              v-model="yearOfRelease"
              type="number"
              :rules="yearValidate"
            ></v-text-field>
            <v-row>
              <v-col cols="12" sm="10">
                <v-select
                  v-model="selectedActors"
                  :items="getActors"
                  item-text="name"
                  item-value="id"
                  label="Select Actors"
                  :rules="[actorValidate]"
                  multiple
                ></v-select>
              </v-col>
              <v-col cols="12" sm="2">
                <v-btn class="primary mt-sm-4" @click="addActor"
                  >Add ACTOR</v-btn
                >
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" sm="10">
                <v-select
                  v-model="selectedProducer"
                  :items="getProducers"
                  item-text="name"
                  item-value="id"
                  label="Select Producer"
                  :rules="producerValidate"
                ></v-select>
              </v-col>
              <v-col cols="12" sm="2">
                <v-btn class="primary mt-sm-4" @click="addProducer"
                  >Add Producer</v-btn
                >
              </v-col>
            </v-row>

            <v-row>
              <v-col>
                <v-select
                  v-model="selectedGenres"
                  :items="getGenres"
                  item-text="name"
                  item-value="id"
                  label="Select Genres"
                  :rules="[genreValidate]"
                  multiple
                ></v-select>
              </v-col>
            </v-row>

            <v-textarea
              v-model="plot"
              :rules="plotValidate"
              label="Plot"
              rows="3"
            ></v-textarea>

            <v-file-input
              v-model="coverImage"
              label="Select a File"
              :rules="imageValidate"
              :value="fileUrl"
              @change="toUpdatePoster"
            ></v-file-input>

            <v-row class="d-flex justify-end mb-4 mt-2">
              <v-btn class="red white--text" type="submit"
                >{{ btnTitle }} Movie</v-btn
              >
            </v-row>
          </v-form>
        </v-container>
      </v-col>
    </v-row>
    <div>
      <add-modal
        v-if="modalVisible"
        :show="modalVisible"
        :title="modaltitle"
        @closemodal="closeModal"
      ></add-modal>
    </div>
  </v-app>
</template>

<script>
import AddModal from "./AddModal.vue";
export default {
  props: ["fid", "getActors", "getProducers", "getGenres", "selectedmovie"],
  emits: ["registermovie"],
  components: {
    AddModal,
  },

  data() {
    return {
      modalVisible: false,
      btnTitle: "Add",
      headTitle: "Enter",
      modaltitle: "",
      movieName: "",
      yearOfRelease: "",
      selectedActors: [],
      selectedProducer: "",
      selectedGenres: [],
      plot: "",

      coverImage: null,
      fileUrl: "",
      updatePoster: false,

      nameValidate: [(v) => !!v || "Movie name can not be empty"],
      yearValidate: [(v) => !!v || "Please select yearofreleases"],

      producerValidate: [(v) => !!v || "Please select producer"],

      plotValidate: [(v) => !!v || "Plot can not be empty"],
      imageValidate: [(v) => !!v || "Please select poster for the movie"],
    };
  },

  created() {
    if (this.fid !== null) {
      this.movieName = this.selectedmovie.name;
      this.yearOfRelease = this.selectedmovie.yearOfRelease;
      this.selectedActors = this.selectedmovie.actors.map((actor) => actor.id);
      this.selectedGenres = this.selectedmovie.genres.map((genre) => genre.id);
      this.selectedProducer = this.selectedmovie.producer.id;
      this.plot = this.selectedmovie.plot;
      this.fileUrl = this.selectedmovie.coverImage;
      let file = new File([], this.selectedmovie.name + "poster.jpg", {
        type: "text/plain",
      });
      this.coverImage = file;

      this.btnTitle = "Update";
      this.headTitle = "Update";
    }
  },

  methods: {
    toUpdatePoster() {
      this.updatePoster = true;
    },
    actorValidate(value) {
      return value.length > 0 || "Please select at least one actor.";
    },
    genreValidate(value) {
      return value.length > 0 || "Please select at least one genre.";
    },

    addActor() {
      this.modalVisible = true;
      this.modaltitle = "Actor";
    },
    addProducer() {
      this.modalVisible = true;
      this.modaltitle = "Producer";
    },
    closeModal() {
      this.modalVisible = false;
    },

    submitMovieData() {
      if (this.$refs.movieform.validate()) {
        const newMovie = {
          name: this.movieName,
          yearofrelease: this.yearOfRelease,
          plot: this.plot,
          actorids: this.selectedActors,
          genreids: this.selectedGenres,
          producerid: this.selectedProducer,
        };

        if (this.updatePoster) {
          newMovie.coverimage = this.coverImage;
        } else {
          newMovie.coverimage = this.fileUrl;
        }

        this.$emit("registermovie", newMovie);
      }
    },
  },
};
</script>

<style scoped>
.containclass {
  background-color: rgb(245, 239, 238);
}
</style>