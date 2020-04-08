import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import Rules from '@/views/Rules.vue'
import JoinGame from '@/views/JoinGame.vue'
import MyGames from '@/views/MyGames.vue'
import CreateGame from '@/views/CreateGame.vue'
import GameDetail from '@/views/GameDetail.vue'
import MyGameDetail from '@/views/MyGameDetail.vue'


// import { RuleTester } from 'eslint'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/rules",
      name: "game-rules",
      component: Rules,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/games/join",
      name: "join-game",
      component: JoinGame,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/games/mygames",
      name: "my-games",
      component: MyGames,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/games/create",
      name: "create-game",
      component: CreateGame,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/game-detail",
      name: "game-detail",
      component: GameDetail,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/mygame-detail",
      name: "mygame-detail",
      component: MyGameDetail,
      meta: {
        requiresAuth: false
      }
    }
  ]
})

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
