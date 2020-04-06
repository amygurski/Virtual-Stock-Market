import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import Login from "./views/Login.vue";
import ViewPost from "./views/ViewPost.vue";
import ViewUser from "./views/ViewUser.vue";
import Favorites from "./views/Favorites.vue";
import NewPost from "./views/NewPost.vue";
import auth from "./shared/auth";

Vue.use(Router);

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authentiated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiesAuth: false
      }
    },
    {
      path: "/post/:id",
      name: "view-post",
      component: ViewPost,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/user/:id",
      name: "view-user",
      component: ViewUser,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/favorites",
      name: "view-favorites",
      component: Favorites,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/post",
      name: "post",
      component: NewPost,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/",
      name: "home",
      component: Home,
      meta: {
        requiresAuth: true
      }
    }
  ]
});

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const user = auth.getUser();

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && !user) {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
