import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router.js';
import store from './store/index.js';


import BaseDialog from './components/ui/BaseDialog.vue';


Vue.config.productionTip = false;

Vue.component('base-dialog',BaseDialog);

new Vue({
  vuetify,
  router,
  store,
  render: h => h(App)
}).$mount('#app')
