import Vue from "vue";
import App from "./App.vue";
import router from "./router";

// This vue project imports the Font Awesome components
// (mainly the heart and the bookmark)
import { library } from "@fortawesome/fontawesome-svg-core";
import { faHeart as fasHeart, faBookmark as fasBookmark } from "@fortawesome/free-solid-svg-icons";
import {
  faHeart as farHeart,
  faBookmark as farBookmark
} from "@fortawesome/free-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

require("./assets/style.css");

library.add(fasHeart, farHeart, fasBookmark, farBookmark);

Vue.component("font-awesome-icon", FontAwesomeIcon);

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
