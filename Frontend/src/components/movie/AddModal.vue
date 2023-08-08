<template>
  <div>
    <v-app>
      <div id="modal">
        <v-dialog v-model="datashow" max-width="600px">
          <!-- v-card is used for content styling, but you can put any content here -->
          <v-card>
            <v-card-title id="dialogtitle" class="blue font-weight-bold">
              <v-card-title>
                <h3 class="white--text">Add {{ thetitle }}</h3>
              </v-card-title>
              <v-spacer></v-spacer>
              <v-btn icon class="pink white--text" @click="closeDialog"
                ><span class="material-symbols-outlined"> close </span></v-btn
              >
            </v-card-title>

            <v-container>
              <h3 class="text-success text-center">
                Enter {{ thetitle }} Details
              </h3>

              <v-form class="font-weight-bold pl-9 pr-9" ref="modalform">
                <v-text-field
                  :label="`Enter ${thetitle} name`"
                  v-model="name"
                  :rules="nameValidate"
                ></v-text-field>
                <v-textarea
                  v-model="bio"
                  label="Bio"
                  rows="3"
                  :rules="bioValidate"
                ></v-textarea>
                <v-menu>
                  <template v-slot:activator="{ on }">
                    <v-text-field
                      v-model="dob"
                      label="DOB"
                      v-on="on"
                      append-icon="mdi-calendar"
                      :rules="dobValidate"
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-model="dob"
                    :rules="dobValidate"
                  ></v-date-picker>
                </v-menu>

                <v-radio-group
                  label="Gender"
                  v-model="gender"
                  :rules="genderValidate"
                >
                  <v-radio label="Male" value="Male"></v-radio>
                  <v-radio label="Female" value="Female"></v-radio>
                </v-radio-group>

                <v-layout class="d-flex justify-center">
                  <v-btn
                    class="pink white--text text-capitalize"
                    @click="AddPerson"
                    >Add
                  </v-btn>
                </v-layout>
              </v-form>
            </v-container>

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
import Swal from "sweetalert2";
export default {
  props: {
    show: {
      type: Boolean,
      default: false,
    },
    title: {
      type: String,
    },
  },
  data() {
    return {
      name: "",
      bio: "",
      dob: "",
      gender: "",
      nameValidate: [(v) => !!v || `${this.thetitle} name can not be empty`],
      bioValidate: [(v) => !!v || "Bio can not be empty"],
      dobValidate: [(v) => !!v || "Please select DOB"],
      genderValidate: [(v) => !!v || "Please select Gender"],
    };
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

    thetitle: {
      get() {
        return this.title;
      },
    },
  },

  emits: ["closemodal"],
  methods: {
    closeDialog() {
      this.$emit("closemodal");
    },

    async AddPerson() {
      if (this.$refs.modalform.validate()) {
        const newPerson = {
          name: this.name,
          bio: this.bio,
          dob: this.dob,
          gender: this.gender,
        };
        if (this.thetitle == "Actor") {
          await this.$store.dispatch("actors/add", newPerson);
          Swal.fire({
            title: "success",
            text: "Actor Added Successfully",
            icon: "success",
            confirmButtonText: "Ok",
          }).then((result) => {
            if (result.isConfirmed) {
              this.closeDialog();
              this.$router.go(0);
            }
          });
        } else if (this.thetitle == "Producer") {
          await this.$store.dispatch("producers/add", newPerson);
          Swal.fire({
            title: "success",
            text: "Producer Added Successfully",
            icon: "success",
            confirmButtonText: "Ok",
          }).then((result) => {
            if (result.isConfirmed) {
              this.closeDialog();
              this.$router.go(0);
            }
          });
        }
      }
    },
  },
};
</script>
<style scoped>
#dialogtitle {
  height: 80px !important;
}
</style>
