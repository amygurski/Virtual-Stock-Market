<template>
   <div id="app">
   <!-- <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <router-link to="/" class="navbar-brand">
   Logo attribution: logo PNG Designed By haris99 from "https://pngtree.com/" Pngtree.com</a> 
  <img id="img-logo-nav" />
  Stock Market Game
  </router-link>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarText">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Features</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Pricing</a>
      </li>
    </ul>
    <span class="navbar-text">
      Navbar text with an inline element
    </span>
  </div>
</nav> -->




     <div id="nav">
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
    <router-view />
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  data() {
    return {
      user: null,
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push('/login');
      this.user = null;
    },
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

</style>
