import Vue from 'vue';
import VueHighlightJS from 'vue-highlightjs';
import App from './App.vue';
import router from './router';
import BootstrapVue from 'bootstrap-vue';

Vue.use(BootstrapVue);
//import 'bootstrap/dist/css/bootstrap.min.css';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.config.productionTip = false;
Vue.use(VueHighlightJS);

new Vue({
  router,
  render: (h) => h(App),
}).$mount('#app');
