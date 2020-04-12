<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark" id="navbar-bg">
    <router-link :to="{path: '/'}" class="navbar-brand">
      <!-- Logo attribution: logo PNG Designed By haris99 from "https://pngtree.com/" Pngtree.com  -->
      <img src="/images/StockMarketLogo.png" id="img-logo-nav" />
      Virtual Stock Market
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <ul class="navbar-nav mr-auto">
      <li class="nav-item">
        <router-link :to="{path: '/'}" class="nav-link">Home</router-link>
      </li>
      <li class="nav-item">
        <router-link :to="{path: '/rules'}" class="nav-link">Rules</router-link>
      </li>
      <li class="nav-item dropdown">
        <a
          class="nav-link dropdown-toggle"
          id="navbarDropdown"
          href="#"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >Games</a>
        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
          <router-link :to="{path: '/games/mygames'}" class="dropdown-item">My Games</router-link>
          <router-link :to="{path: '/games/join'}" class="dropdown-item">Join a Game</router-link>
          <router-link :to="{path: '/games/create'}" class="dropdown-item">Create New Game</router-link>
        </div>
      </li>
      <li class="nav-item">
        <router-link :to="{path: '/stocks/research'}" class="nav-link">Research Stocks</router-link>
      </li>
      <li v-show="user && user.rol === 'Admin'" class="nav-item">
        <router-link :to="{name: 'admin'}" class="nav-link">Super Secret</router-link>
      </li>
      <!-- TODO: Remove unnecessary links after chart tests -->
      <li>
        <router-link to="/chartjs">vue-chartjs</router-link>
      </li>
    </ul>
    <ul v-if="user" class="navbar-nav ml-auto">
      <li class="nav-item">
        <a v-on:click="logout" class="nav-link" id="logout-button">Logout</a>
      </li>
    </ul>
    <ul v-else class="navbar-nav ml-auto">
      <li class="nav-item">
        <router-link :to="{path: '/register'}" class="nav-link">Register</router-link>
      </li>
      <li class="nav-item">
        <router-link :to="{path: '/login'}" class="nav-link">Login</router-link>
      </li>
    </ul>
  </nav>
</template>

<script>
import auth from "@/auth.js";

export default {
  name: "navbar",
  data() {
    return {
      user: null
    };
  },
  methods: {
    logout() {
      auth.logout();
      // this.$router.push("/");
      this.user = null;
    }
  },
  created() {
    this.user = auth.getUser();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
  }
};
</script>

<style scoped>
#img-logo-nav {
  width: 36px;
}

/* a.nav-link :hover {
    cursor: pointer;
} */

#logout-button {
  cursor: pointer;
}

#navbar-bg {
  background-color: #282a2e !important;
}
</style>