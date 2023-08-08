import Vue from 'vue';
import VueRouter from 'vue-router';
import ActorList from './pages/ActorList.vue';
import AddMovie from './pages/AddMovie.vue';
import MovieList from './pages/MovieList.vue';
import ProducerList from './pages/ProducerList.vue';
import NotFound from './pages/NotFound.vue';


Vue.use(VueRouter);

const routes = [
  {path:'/',redirect:'/movies'},
  {path:'/movies',component:MovieList},
  {path:'/movies/:id',component:AddMovie},
  {path:'/actors',component:ActorList},
  {path:'/producers',component:ProducerList},
  {path:'/addMovie',component:AddMovie},
  {path:'/notFound(.*)',component:NotFound}
];

const router = new VueRouter({
    mode:'history',

  routes
});

export default router;
