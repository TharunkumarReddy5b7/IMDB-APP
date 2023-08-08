<template>
  <div>
    <v-app>
      <div id="modal">
        <v-dialog v-model="datashow" max-width="600px">
          <!-- v-card is used for content styling, but you can put any content here -->
          <v-card>
            <v-card-title class="blue white--text font-weight-bold">
              <v-card-title>
                <h3>Movie Details</h3>
              </v-card-title>
              <v-spacer></v-spacer>
              <v-btn icon class="pink white--text" @click="closeDialog"
                ><span class="material-symbols-outlined"> close </span></v-btn
              >
            </v-card-title>

            <div class="ma-2">
              <v-img :src="movie.coverImage"></v-img>
            </div>

            <div class="ma-2">
              <table class="table">
                <thead>
                  <tr>
                    <th scope="col">Title</th>
                    <th scope="col" class="text-primary">{{ movie.name }}</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <th scope="row">yearOfRelease</th>
                    <td>{{ movie.yearOfRelease }}</td>
                  </tr>
                  <tr>
                    <th scope="row">plot</th>
                    <td>
                      {{ movie.plot }}
                    </td>
                  </tr>
                  <tr>
                    <th scope="row">Actors</th>
                    <td>
                      <ul style="margin: 0; padding: 0; list-style-type: none">
                        <li v-for="actor in movie.actors" :key="actor">
                          {{ actor.name }}
                        </li>
                      </ul>
                    </td>
                  </tr>
                  <tr>
                    <th scope=" row">Genres</th>
                    <td>
                      <ul style="margin: 0; padding: 0; list-style-type: none">
                        <li v-for="genre in movie.genres" :key="genre">
                          {{ genre.name }}
                        </li>
                      </ul>
                    </td>
                  </tr>

                  <tr>
                    <th scope="row">Producer</th>
                    <td>{{ movie.producer.name }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <v-divider></v-divider>
            <v-card-actions>
              <!-- Button to close the popup -->
              <v-layout class="d-flex justify-end">
                <v-btn color="red white--text" @click="closeDialog"
                  >Close</v-btn
                >
              </v-layout>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </div>
    </v-app>
  </div>
</template>

<script>
export default {
  props: {
    show: {
      type: Boolean,
      default: false,
    },
    movie: {
      type: Object,
    },
  },

  computed: {
    datashow: {
      get() {
        return this.show;
      },
      set() {
        this.$emit("closemodal");
      },
    },
  },

  emits: ["closemodal"],
  methods: {
    closeDialog() {
      this.$emit("closemodal");
    },
  },
};
</script>
<style scoped>
tr,
td {
  margin: 6px;
}
</style>
