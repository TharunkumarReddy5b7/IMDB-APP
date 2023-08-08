<template>
  <v-app id="jhj" app>
    <v-toolbar class="red myrls">
      <v-toolbar-title class="tool">
        <img src="../../assets/IMDB.png" height="40" alt="Logo" />
      </v-toolbar-title>
      <v-toolbar-title class="tool ml-4">
        <h2 class="align-center">IMDB</h2>
      </v-toolbar-title>
      <v-spacer></v-spacer>

      <v-toolbar-items class="tool hidden-sm-and-down">
        <v-btn class="mr-2 navlink" depressed to="/movies">Movies</v-btn>
        <v-btn class="mr-2 navlink" depressed to="/actors">Actors</v-btn>
        <v-btn class="mr-2 navlink" depressed to="/producers">Producers</v-btn>
      </v-toolbar-items>

      <v-btn class="hidden-md-and-up" icon @click="toggleDrawer">
        <v-icon>mdi-menu</v-icon>
      </v-btn>
    </v-toolbar>

    <v-navigation-drawer
      v-if="drawer"
      v-model="drawer"
      class="red hidden-md-and-up"
      app
    >
      <v-list class="mt-5">
        <v-list-item class="list-item white--text" to="/movies">
          <v-list-item-title>Movies</v-list-item-title>
        </v-list-item>
        <v-list-item class="list-item white--text" to="/actors">
          <v-list-item-title>Actors</v-list-item-title>
        </v-list-item>
        <v-list-item class="list-item white--text" to="/producers">
          <v-list-item-title>Producers</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-app>

  <!-- Your main content goes here -->
</template>

<script>
export default {
  data() {
    return {
      drawer: false,
    };
  },
  methods: {
    toggleDrawer() {
      this.drawer = !this.drawer;
    },
  },
};
</script>
<style scoped>
#jhj {
  height: 80px;
}

.myrls {
  height: 60px !important;
  position: fixed;
  top: 0;
  width: 100%;
}

.tool {
  height: 40px;
}

.navlink:hover {
  background-color: rgb(2, 137, 255);
  color: white;
  text-decoration: none;
}
.list-item {
  text-decoration: none;
}
.list-item:hover {
  background-color: rgb(2, 137, 255) !important;
  color: white;
}
</style>


