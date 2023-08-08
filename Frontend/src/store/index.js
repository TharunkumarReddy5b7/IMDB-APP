import Vue from 'vue';
import Vuex from 'vuex';
import ActorsModule from './modules/Actor.js';
import GenresModule from './modules/Genre.js';
import ProducerModule from './modules/Producer.js';
import MoviesModule from './modules/Movie.js';

Vue.use(Vuex);

export default new Vuex.Store({
    modules:{
        actors:ActorsModule,
        genres:GenresModule,
        producers:ProducerModule,
        movies:MoviesModule
    }
  });
  