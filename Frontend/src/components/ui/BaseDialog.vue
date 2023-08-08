<template>
  <div>
    <v-app>
      <div id="modal">
        <v-dialog v-model="datashow" max-width="500px">
          <!-- v-card is used for content styling, but you can put any content here -->
          <v-card>
            <v-card-title class="red white--text font-weight-bold">
              <v-card-title>
                <h3>An Error Occured</h3>
              </v-card-title>
              <v-spacer></v-spacer>
              <v-btn icon class="white--text" @click="closeDialog"
                ><span class="material-symbols-outlined"> close </span></v-btn
              >
            </v-card-title>

            <v-card-text
              ><h4 class="mt-6 text-center">{{ error }}</h4></v-card-text
            >

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
    error: {
      type: String,
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
