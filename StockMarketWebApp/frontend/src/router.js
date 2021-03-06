import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Index from './views/Index.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import Rules from '@/views/Rules.vue'
import JoinGame from '@/views/JoinGame.vue'
import MyGames from '@/views/MyGames.vue'
import CreateGame from '@/views/CreateGame.vue'
import JoinGameDetail from '@/views/JoinGameDetail.vue'
import GameDetail from '@/views/GameDetail.vue'
import AdminControlPanel from '@/views/AdminControlPanel.vue'
import ResearchStocks from '@/views/ResearchStocks.vue'
import StockDetails from '@/views/StockDetails.vue'
import OwnedStocks from '@/views/OwnedStocks'
import SellStock from '@/views/SellStock'
import AvailableStocks from '@/views/AvailableStocks'
import ConfirmStockPurchase from "@/views/ConfirmStockPurchase"
import VueChartJS from '@/views/VueChartJS'


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

 /* Todo Refactor with names?*/

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      component: Index,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/rules",
      component: Rules,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/games/join",
      component: JoinGame,
      name: "join-game",
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/games/mygames",
      name: "my-games",
      component: MyGames,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/games/create",
      name: "create-game",
      component: CreateGame,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/join-game-detail/:id",
      name: "join-game-detail",
      component: JoinGameDetail,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/game-detail/:id",
      name: "game-detail",
      component: GameDetail,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/stocks/research",
      component: ResearchStocks,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/admin",
      name: "admin",
      component: AdminControlPanel,
      meta: {
        requiresAuth: true,
        isAdmin: true
      }
    },
    {
      path: "/stocks/research/:stockSymbol",
      name: "stock-details",
      component: StockDetails,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/stocks/owned",
      name: "owned-stocks",
      component: OwnedStocks,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/stocks/owned/sell",
      name: "sell-stock",
      component: SellStock,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/stocks/available",
      name: "available-stocks",
      component: AvailableStocks,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/stocks/available/confirmpurchase",
      name: "confirm-purchase",
      component: ConfirmStockPurchase,
      meta: {
        requiresAuth: false
      }
    },
    // TODO: Remove unnecessary chart wrappers after testing
    {
      path: '/chartjs',
      name: 'VueChartJS',
      component: VueChartJS
    },
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const user = auth.getUser();
  const isAdmin = to.matched.some(x => x.meta.isAdmin);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && !user) {
    const loginpath = router.currentRoute.path;
    console.log("path: " + loginpath)
    //next("/login");
    next( { path: '/login', query: { from: loginpath } } );
  } 
  else if ( isAdmin && user.rol !== 'Admin' ) {
    auth.logout();
    next( { path: '/login', query: { from: "/" } } );
  }
  else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
