<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <router-link to="/" class="navbar-brand">
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
        <li class="nav-item active">
          <a class="nav-link" href="#">
            Home
            <span class="sr-only">(current)</span>
          </a>
        </li>
        <li class="nav-item">
          <router-link :to="{name: 'game-rules'}" class="nav-link">Rules</router-link>
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
            <router-link :to="{name: 'my-games'}" class="dropdown-item">My Games</router-link>
            <router-link :to="{name: 'join-game'}" class="dropdown-item">Join a Game</router-link>
            <router-link :to="{name: 'create-game'}" class="dropdown-item">Create New Game</router-link>
          </div>
        </li>
        <li class="nav-item">
          <router-link :to="{name: research-stocks}" class="nav-link">Research Stocks</router-link>
        </li>
      </ul>
      <ul v-if="user" class="navbar-nav ml-auto">
        <li><button v-on:click="logout">Logout</button></li>
      </ul>
      <ul v-else class="navbar-nav ml-auto">
        <li class="nav-item"><router-link :to="{name: 'register'}" class="nav-link">Register</router-link></li>
        <li class="nav-item"><router-link :to="{name: 'login'}" class="nav-link">Login</router-link></li>
      </ul>
    </nav>
    <router-view />

    <!-- <div id="nav">
      <div v-if="user">
        Logged in
        <div>
          <button v-on:click="logout">Logout</button>
        </div>
      </div>
      <div v-else>
        <div>
          <router-link :to="{name: 'login'}">Login</router-link>
        </div>
        <div>
          <router-link :to="{name: 'register'}">Register</router-link>
        </div>
      </div>
      <router-link to="/">Home</router-link>
    </div>
    <router-view />-->
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  data() {
    return {
      user: null
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push("/login");
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

</style>
